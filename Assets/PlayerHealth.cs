using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : LivingEntity
{
    private float health;
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
        health_Text.text  = mana.ToString();
        mana_Text.text  = health.ToString();
        stamina_Text.text  = stamina.ToString();
    }

    public void ChangeHealth(float amount)
    {
        health_Text.text = (health + amount).ToString();
    }
}