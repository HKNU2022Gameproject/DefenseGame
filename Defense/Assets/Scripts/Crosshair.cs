using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image aimPointReticle; // 화면상 크로스헤어를 나타내는 이미지
    public Image hitPointReticle; // 실제로 맞게되는 크로스헤어를 나타내는 이미지

    public float smoothTime = 10f; // 0.2 초의 지연시간

    private Camera screenCamera;
    private RectTransform crossHairRectTransform;

    private Vector3 currentHitPointVelocity; // smoothing에 사용할 값의 변화량
    private Vector2 targetPoint;

    private void Awake() // 메인 카메라 가져와서 할당
    {
        screenCamera = Camera.main;
        crossHairRectTransform = hitPointReticle.GetComponent<RectTransform>();
    }

    public void SetActiveCrosshair(bool active) // active 값에 따라 두 크로스 헤어를 모두 활성화 or 비활성화
    {
        hitPointReticle.enabled = active;
        aimPointReticle.enabled = active;
    }

    public void UpdatePosition(Vector3 worldPoint) // 월드 좌표계 위치를 입력으로 받아서 화면상 좌표계로 변환하여 targetPoint에 대입
    {
        targetPoint = screenCamera.WorldToScreenPoint(worldPoint);
    }

    // 매 프레임마다 hitPointReticle 이미지의 위치(crossHairRectTransform)를 실제로 총이 맞는 위치에 그려주는 역할
    private void Update()
    {
        if (!hitPointReticle.enabled) return;

        crossHairRectTransform.position = Vector3.SmoothDamp(crossHairRectTransform.position, targetPoint,
            ref currentHitPointVelocity, smoothTime * Time.deltaTime);
    }
}