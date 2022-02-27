using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController; // 이 컴포넌트를 통해 Player Character 오브젝트의 Collider 처리
    private PlayerInput playerInput; // 얘로부터 입력 감지를 받아야 함
    private Animator animator; // 애니메이션을 제어
    private PlayerShooter playerShooter;

    private Camera followCam; // Main Camera

    public float speed = 6f;
    public float jumpVelocity = 20f;
    [Range(0.01f, 1f)] public float airControlPercent;

    public float speedSmoothTime = 0.1f;
    public float turnSmoothTime = 0.1f;
    
    private float speedSmoothVelocity;
    private float turnSmoothVelocity;
    
    private float currentVelocityY;
    
    public float currentSpeed =>
        new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        followCam = Camera.main;
        playerShooter = GetComponent<PlayerShooter>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (currentSpeed > 0.2f || playerInput.fire) Rotate();

        Move(playerInput.moveInput);
        
        if (playerInput.jump) Jump();

        UpdateAnimation(playerInput.moveInput);
    }


    public void Move(Vector2 moveInput) // 유저의 입력값에 따른 이동. 매번 물리 갱신 주기마다 실행한다.
    {
        var targetSpeed = speed * moveInput.magnitude;
        var moveDirection = Vector3.Normalize(transform.forward * moveInput.y + transform.right * moveInput.x);
        
        var smoothTime = characterController.isGrounded ? speedSmoothTime : speedSmoothTime / airControlPercent;

        targetSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, smoothTime);
        currentVelocityY += Time.deltaTime * Physics.gravity.y;

        var velocity = moveDirection * targetSpeed + Vector3.up * currentVelocityY;

        characterController.Move(velocity * Time.deltaTime);

        if (characterController.isGrounded) currentVelocityY = 0;
    }

    //물리 갱신 주기에 맞춰 자동 실행. 회전(Rotate), 이동(Move) 담당
    public void Rotate()
    {
        var targetRotation = followCam.transform.eulerAngles.y;

        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,
                                    ref turnSmoothVelocity, turnSmoothTime);
    }

    public void Jump() // 점프 입력이 감지되면 점프 실행
    {
        if (!characterController.isGrounded) return;
        currentVelocityY = jumpVelocity;
    }

    private void UpdateAnimation(Vector2 moveInput)
    {
        var animationSpeedPercent = currentSpeed / speed;

        animator.SetFloat("Horizontal Move", moveInput.x * animationSpeedPercent, 0.05f, Time.deltaTime);
        animator.SetFloat("Vertical Move", moveInput.y * animationSpeedPercent, 0.05f, Time.deltaTime);
    }
}