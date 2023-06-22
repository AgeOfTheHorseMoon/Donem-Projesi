using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : LivingEntity
{
    public float health;
    public float maxHealth;
    public float stamina;
    public float mana;

    [SerializeField]
    private TMP_Text health_Text;
    [SerializeField]
    private TMP_Text mana_Text;
    [SerializeField]
    private TMP_Text stamina_Text;

    void Start()
    {
        health = startingHealth;
        health_Text.text  = health.ToString(); 
        mana_Text.text  = mana.ToString();
        stamina_Text.text  = stamina.ToString();
    }

    public void ChangeHealth(float amount)
    { 
        Debug.Log("healt points" + amount);
        health_Text.text = (health + amount).ToString();
        health += amount;
    }
}