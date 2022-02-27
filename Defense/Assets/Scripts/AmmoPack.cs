using UnityEngine;


// AmmoPack 프리팹 아이템임을 나타내는 코드
public class AmmoPack : MonoBehaviour, IItem
{
    public int ammo = 30;

    public void Use(GameObject target)
    {
        var playerShooter = target.GetComponent<PlayerShooter>();
        
        if (playerShooter != null && playerShooter.gun != null)
        {
            playerShooter.gun.ammoRemain += ammo;
        }
        
        Destroy(gameObject);
    }
}