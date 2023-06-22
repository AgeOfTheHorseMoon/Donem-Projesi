using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
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
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<LivingEntity>().GetHealth();
        health_Text.text  = health.ToString(); 
        mana_Text.text  = mana.ToString();
        stamina_Text.text  = stamina.ToString();
    }

    public void ChangeHealth(float amount)
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<LivingEntity>().GetHealth();
        Debug.Log("healt points" + amount);
        health_Text.text = (health + amount).ToString();
        GameObject.FindGameObjectWithTag("Player").GetComponent<LivingEntity>().SetHealth(amount);
    }
}