using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    void Update()
    {
        // 아이템처럼 보이게 계속 회전한다.
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
