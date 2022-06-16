using DaemonsGate.Health;
using DaemonsGate.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour, IBullet
{
    [SerializeField]
    int damage;

    public void Damage(float damage)
    {
        GetComponent<HealthControl>().TakeDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject.transform.parent.gameObject;
        if (target.CompareTag("Player"))
        {
            target.GetComponent<HealthControl>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
