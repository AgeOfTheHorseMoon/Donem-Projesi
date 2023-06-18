using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    public enum EnemyType
    {
        Ranged, Melee
    }
    
    [SerializeField] EnemyType type;

    [SerializeField] float searchRange;

    [SerializeField] LayerMask playerMask;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField]Transform attackPoint;

    [SerializeField] float fireRate = 2f, attackRadius, damage = 10f;

    float timer;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Target in range
        if(Physics.CheckSphere(transform.position, searchRange, playerMask))
        {
            if(type == EnemyType.Melee)
            {
                // hit player with or without animation
                MeleeAttack();
            }
            else if (type == EnemyType.Ranged)
            {
                // spawn projectile, put it on timer
                RangedAttack();
            }
        }
    }

    private void RangedAttack()
    {
        timer += Time.deltaTime;

        // Shoot when fireRate matched
        if(timer > fireRate)
        {
            timer = 0f;
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }

    private void MeleeAttack()
    {
        timer += Time.deltaTime;

        if(timer > fireRate)
        {
            timer = 0f;
            
            // Player in range
            if(Physics.CheckSphere(attackPoint.position, attackRadius, playerMask))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<LivingEntity>().TakeHit(damage);
            }
        }
    }
}
