using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField] private float lastPosY = 0f;
    [SerializeField] private float fallDistance = 0f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CharacterController characterController;
    
}
