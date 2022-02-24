using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveHorizintalAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public string moveVerticalAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    
    public string jumpButtonName = "Jump"; // 점프를 위한 입력 버튼 이름
    public string fireButtonName = "Fire1"; // 공격을 위한 입력 버튼 이름
    public string reloadButtonName = "Reload"; // 재장전을 위한 입력 버튼 이름

    // 값 할당은 내부에서만 가능하다.
    public Vector2 moveInput { get; private set; } // Horizontal, Vertical
    public bool fire { get; private set; } // 감지된 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값
    public bool jump { get; private set; } // 감지된 점프 입력값

    void Update()
    {
        // 게임오버 상태에서는 사용자 입력을 감지하지 않는다.
        if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            moveInput = Vector2.zero;
            fire = false;
            reload = false;
            jump = false;
            return;
        }

        // move에 관한 입력 감지
        moveInput = new Vector2(Input.GetAxis(moveHorizintalAxisName), Input.GetAxis(moveVerticalAxisName));
        // 키보드로 수평, 수직 입력을 같이 하면 값이 1이 아니라 루트2(가로, 세로 길이가 1인 직사각형의 빗변)가
        // 입력되어 그냥 앞으로 가는 것보다 더 빠르게 이동한다.
        // 그래서 벡터의 길이 제곱(sqrtMagnitude)이 1을 넘을 경우 똑같은 방향의 길이가 1인 벡터(normalized)로
        // 바꾸어 준다.
        if (moveInput.sqrMagnitude > 1)
        {
            moveInput = moveInput.normalized;
        }

        // jump에 관한 입력 감지
        jump = Input.GetButtonDown(jumpButtonName);
        // fire에 관한 입력 감지
        fire = Input.GetButton(fireButtonName);
        // reload에 관한 입력 감지
        reload = Input.GetButtonDown(reloadButtonName);
    }
}
