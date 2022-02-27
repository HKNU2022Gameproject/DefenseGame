using UnityEngine;


// Coin ������ ���������� ��Ÿ���� �ڵ�
public class Coin : MonoBehaviour, IItem
{
    public int score = 200;

    public void Use(GameObject target)
    {
        GameManager.Instance.AddScore(score);
        Destroy(gameObject);
    }
}