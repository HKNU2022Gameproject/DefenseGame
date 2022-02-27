using UnityEngine;


// Coin 프리팹 아이템임을 나타내는 코드
public class Coin : MonoBehaviour, IItem
{
    public int score = 200;

    public void Use(GameObject target)
    {
        GameManager.Instance.AddScore(score);
        Destroy(gameObject);
    }
}