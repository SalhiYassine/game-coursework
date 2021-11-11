using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerController playerMovement;
    private float coolDownTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        coolDownTimer = 0;
    }

}
