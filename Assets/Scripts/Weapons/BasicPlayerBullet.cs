using DaemonsGate.Health;
using DaemonsGate.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerBullet : MonoBehaviour, IBullet
{
    [SerializeField]
    int damage;


    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject.transform.parent.gameObject;
        if (target.CompareTag("Player"))
        {
            target.GetComponent<HitBox>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
