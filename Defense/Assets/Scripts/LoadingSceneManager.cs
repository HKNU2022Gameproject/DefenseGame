using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 씬을 이동할때 자동으로 로딩씬을 띄워주는 코드
public class LoadingSceneManager : MonoBehaviour
{

    public static string nextScene;
    public Image ProgressBar;
    public Text LoadingText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadingScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); // 비동기 로딩 사용
        op.allowSceneActivation = false;

        float timer = 0;

        while (!op.isDone) // 로딩이 전부 차면 씬 이동
        {
            yield return null;

            timer += Time.deltaTime / 2;

            if (op.progress >= 0.9f)
            {
                ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, 1f, timer);

                if (ProgressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                }
            }
            else
            {
                ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, op.progress, timer);
                if (ProgressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }

            float Loading = ProgressBar.fillAmount * 100;

            LoadingText.text = ("LOADING : " + Loading.ToString("N1") + "%"); // 텍스트 출력

        }
    }
}