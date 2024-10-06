using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public float PlayerSpeed { get; private set; }
    [field: SerializeField] public float PlayerJumpForce { get; private set; }
    [field: SerializeField] public int PlayerHPs { get; private set; }
    [field: SerializeField] public float Gravity;
    [field: SerializeField ] public Rigidbody PlayerRb { get; private set; }
    [field: SerializeField] public Animator PlayerAnimator { get; private set; }
    [field: SerializeField] public Transform LegsTransform { get; private set; }
    [field: SerializeField] public LayerMask Ground { get; private set; }
}
