using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Projectile : MonoBehaviour
{
    Transform playerTransform;

    public float Damage { get; set; }
    public float LifeTime { get; set; }

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Vector3 direction = transform.position - playerTransform.position;
        transform.localRotation = Quaternion.Euler(direction);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward);

        // if not hit anything
        Destroy(this.gameObject, LifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LivingEntity>() != null)
        {
            other.GetComponent<LivingEntity>().TakeHit(Damage);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
