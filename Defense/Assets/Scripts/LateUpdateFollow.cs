using UnityEngine;

public class LateUpdateFollow : MonoBehaviour
{
    public Transform targetToFollow; // 따라갈 대상 Transform

    private void LateUpdate()
    {
        // 매 프레임마다 덮어 씌운다.
        transform.position = targetToFollow.position;
        transform.rotation = targetToFollow.rotation;
    }
}