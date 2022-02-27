using UnityEngine;

public struct DamageMessage
{
    public GameObject damager; // 공격을 가한 오브젝트
    public float amount; // 공격량 amount

    public Vector3 hitPoint; // 공격을 가한 위치 hitPoint
    public Vector3 hitNormal; // 공격을 가한 평면의 노말 벡터
}