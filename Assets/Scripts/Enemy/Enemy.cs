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

    [SerializeField] LayerMask playerMask;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform attackPoint;

    [SerializeField]
    float
        attackRate = 2f, attackRadius, meleeDamage;

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
        if(Physics.CheckSphere(transform.position, attackRadius, playerMask))
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
        if(timer > attackRate)
        {
            timer = 0f;
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);
            Vector3 direction = (GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position - attackPoint.position).normalized;
            projectile.GetComponent<Projectile>().Setup(direction);
        }
    }

    private void MeleeAttack()
    {
        timer += Time.deltaTime;

        if(timer > attackRate)
        {
            timer = 0f;
            
            // Player in range
            if(Physics.CheckSphere(attackPoint.position, attackRadius, playerMask))
            {
                Collider[] targets = Physics.OverlapSphere(attackPoint.position, attackRadius, playerMask);

                foreach (var target in targets)
                {
                    if (target.CompareTag("Player"))
                    {
                        target.GetComponent<LivingEntity>().TakeHit(meleeDamage);
                        Debug.Log(target.name + " hit for: " + meleeDamage);
                    }
                }
            }
        }
    }
}
