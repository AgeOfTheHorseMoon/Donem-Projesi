using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    LayerMask collisionMask;

    [SerializeField]
    float speed = 20f, damage = 5f, lifeTime = 6f;

    Vector3 shootDirection;

    public void Setup(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
        transform.LookAt(shootDirection);
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += shootDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<LivingEntity>() != null)
        {
            other.GetComponent<LivingEntity>().TakeHit(damage);
            Destroy(this.gameObject);
        }
    }
}
