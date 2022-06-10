using DaemonsGate.Interfaces;
using UnityEngine;



public class BaseEnemy : MonoBehaviour, IEnemy
{
    public GameObject GameObject => (gameObject);

    public float ShootingDistance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
