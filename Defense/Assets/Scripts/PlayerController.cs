using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Animator animator; // 아이템을 먹을 때 애니메이션 처리를 하기 위해
    public AudioClip itemPickupClip; // 아이템을 먹을 때 재생할 오디오 클립
    public int lifeRemains = 3; // 남은 생명 수
    private AudioSource playerAudioPlayer;
    // 오브젝트에 붙어있는 다른 스크립트들을 일괄적으로 제어
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private PlayerShooter playerShooter;

    // Start is called before the first frame update
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
        playerHealth = GetComponent<PlayerHealth>();
        playerAudioPlayer = GetComponent<AudioSource>();
        playerHealth.OnDeath += HandleDeath;

        UIManager.Instance.UpdateLifeText(lifeRemains);
        Cursor.visible = false;
        
    }
    
    private void HandleDeath() // 플레이어가 사망하면 HandleDeath() 함수를 실행
    {
        // 플레이어가 사망 상태가 되면 특정 컴포넌트들 비활성화
        playerMovement.enabled = false;
        playerShooter.enabled = false;

        if (lifeRemains > 0)
        {
            lifeRemains--;
            UIManager.Instance.UpdateLifeText(lifeRemains);
            Invoke("Respawn", 3f);
        }
        else
        {
            GameManager.Instance.EndGame();
        }
        
        Cursor.visible = true;
    }

    public void Respawn()
    {
        gameObject.SetActive(false);
        transform.position = Utility.GetRandomPointOnNavMesh(transform.position, 30f, NavMesh.AllAreas);

        gameObject.SetActive(true);
        playerMovement.enabled = true;
        playerShooter.enabled = true;

        playerShooter.gun.ammoRemain = 120;

        Cursor.visible = false;
    }


    // 아이템과 충돌 됐을 때 실행되는 이벤트 함수.
    private void OnTriggerEnter(Collider other)
    {
        // 아이템과 충돌한 경우 해당 아이템을 사용하는 처리
        // 사망하지 않은 경우에만 아이템 사용가능
        if (!playerHealth.dead)
        {
            // 충돌한 상대방으로 부터 Item 컴포넌트를 가져오기 시도
            var item = other.GetComponent<IItem>();

            // 충돌한 상대방으로부터 Item 컴포넌트가 가져오는데 성공했다면
            if (item != null)
            {
                // Use 메서드를 실행하여 아이템 사용
                item.Use(gameObject);
                // 아이템 습득 소리 재생
                playerAudioPlayer.PlayOneShot(itemPickupClip);
            }
        }
    }
}