using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance; // 싱글톤. private.

    public static UIManager Instance // 이 프로퍼티를 통해서 UIManager의 싱글톤 private 인스턴스를 리턴 받음.
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<UIManager>(); // 인스턴스가 이미 존재할 땐 받지 않는다. 즉, null 일때만 받음.

            return instance;
        }
    }

    // UHD Canvas 의 구성 UI 요소들.
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private Crosshair crosshair;

    [SerializeField] private Text healthText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text ammoText;
    [SerializeField] private Text waveText;

    public void UpdateAmmoText(int magAmmo, int remainAmmo) // 'ammoText' 남은 탄창 UI 갱신
    {
        ammoText.text = magAmmo + "/" + remainAmmo;
    }

    public void UpdateScoreText(int newScore) // 'scoreText' 코인 UI 갱신
    {
        scoreText.text = " " + newScore;
    }
    
    public void UpdateWaveText(int waves, int count) // 'waveText', 남은 적의 수 UI 갱신
    {
        waveText.text = "Wave : " + waves;
    }

    public void UpdateLifeText(int count)  // 'lifeText' 남은 생명 수 UI 갱신
    {
        lifeText.text = " " + count;
    }

    public void UpdateCrossHairPosition(Vector3 worldPosition) // 해당 위치에 크로스 헤어 UI를 표시
    {
        crosshair.UpdatePosition(worldPosition);
    }
    
    public void UpdateHealthText(float health) // 'healthText' 남은 HP UI 갱신
    {
        healthText.text = Mathf.Floor(health).ToString();
    }
    
    public void SetActiveCrosshair(bool active) // 크로스 헤어 UI 활성화
    {
        crosshair.SetActiveCrosshair(active);
    }
    
    public void SetActiveGameoverUI(bool active) // 게임 오버시 'GameOver' UI 활성화
    {
        gameoverUI.SetActive(active);
    }
    
    public void GameRestart() // 게임 Over 상태에서 Restart 버튼을 눌렀을 때 실행시킬 함수. 게임 재 시작
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}