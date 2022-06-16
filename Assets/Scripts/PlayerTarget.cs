using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField]
    Transform _playerTarget;

    public Transform Target { get => _playerTarget; set => _playerTarget = value; }
}
