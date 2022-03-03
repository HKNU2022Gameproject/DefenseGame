using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartClick : MonoBehaviour
{
    public void SceneChange()  // 게임 시작 버튼을 누르면 게임씬으로 이동
    {
        SceneManager.LoadScene("GameScene");
    }

}
