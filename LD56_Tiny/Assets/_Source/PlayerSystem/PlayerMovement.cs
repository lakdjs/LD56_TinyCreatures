using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : IMovable
{
    private float _speed;
    private Rigidbody _rb;
    private float _jumpforce;

    public PlayerMovement(float speed, Rigidbody rb, float jumpforce)
    {
        _speed = speed;
        _rb = rb;
        _jumpforce = jumpforce;
    }

    public void Move(Vector3 dir)
    {
        _rb.velocity = new Vector3(dir.x * _speed, _rb.velocity.y);
    }

    public void Jump(int jumpIter)
    {
        _rb.AddForce(Vector3.up * _jumpforce * jumpIter);
    }
}
