using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    
    public static UIManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<UIManager>();

            return instance;
        }
    }

    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private Crosshair crosshair;

    [SerializeField] private Text healthText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text bulbText;
    [SerializeField] private Text waveText;
    [SerializeField] private Text coinText;

    public void UpdateBulbText(int newBulb)
    {
        bulbText.text = " " + newBulb;
    }
    
    public void UpdateWaveText(int waves)
    {
        waveText.text = " " + waves;
    }

    public void UpdateLifeText(int count)
    {
        lifeText.text = " " + count;
    }

    public void UpdateCoinText(int count)
    {
        coinText.text = " " + count;
    }
    public void UpdateScoreText(int count)
    {
        coinText.text = " " + count;
    }

    public void UpdateCrossHairPosition(Vector3 worldPosition)
    {
        crosshair.UpdatePosition(worldPosition);
    }
    
    public void UpdateHealthText(float health)
    {
        healthText.text = Mathf.Floor(health).ToString();
    }
    
    public void SetActiveCrosshair(bool active)
    {
        crosshair.SetActiveCrosshair(active);
    }
    
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }
    
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}