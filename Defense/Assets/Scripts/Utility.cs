using UnityEngine;
using UnityEngine.AI;

public static class Utility
{
    // NavMesh 위에서 어떤 위치와 반경을 기준으로 랜덤한 위치 리턴
    public static Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance, int areaMask) // // 인수 👉 중심 위치, 반경 거리, 검색할 Area (내부적으로 int)
    {
        var randomPos = Random.insideUnitSphere * distance + center; // // center를 중점으로 하여 반지름(반경) distance 내에 랜덤한 위치 리턴.

        NavMeshHit hit; // NavMesh 샘플링의 결과를 담을 컨테이너. Raycast hit 과 비슷

        NavMesh.SamplePosition(randomPos, out hit, distance, areaMask);

        return hit.position; // 샘플링 결과 위치인 hit.position 리턴
    }
    
    public static float GetRandomNormalDistribution(float mean, float standard)
    {
        var x1 = Random.Range(0f, 1f);
        var x2 = Random.Range(0f, 1f);
        return mean + standard * (Mathf.Sqrt(-2.0f * Mathf.Log(x1)) * Mathf.Sin(2.0f * Mathf.PI * x2));
    }
}