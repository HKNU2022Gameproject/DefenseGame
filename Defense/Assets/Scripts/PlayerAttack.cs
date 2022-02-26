using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator animator;
    public Weapon weapon;
    private float fireDelay;
    private bool isFireReady;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (playerInput.fire == true)
        {
            Attack();
        }
    }
    
    public void Attack()
    {
        fireDelay += Time.deltaTime;
        isFireReady = weapon.rate < fireDelay;

        if (isFireReady == true)
        {
            weapon.Use();
            animator.SetTrigger("Swing");
            fireDelay = 0;
        }
    }
}
