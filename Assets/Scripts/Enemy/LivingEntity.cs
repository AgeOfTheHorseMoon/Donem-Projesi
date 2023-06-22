using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;

    // protected will give you the ability to use it on a derived class
    protected float Health { get; set; }
    protected bool dead;

    public virtual void Start()
    {
        Health = startingHealth;
    }

    public void TakeHit(float damage)
    {
        Health -= damage;

        if(Health <= 0 && !dead)
        {
            Die();
        }

        Debug.Log("Damage Taken: " + damage + " Current HP: " + Health + "Dead: " + dead);
    }

    private void Die()
    {
        dead = true;
        // Change this if you want to do something else like changing visuals etc.
        Destroy(this.gameObject);
    }

    internal void TakeHit(object damage)
    {
        throw new NotImplementedException();
    }
}
