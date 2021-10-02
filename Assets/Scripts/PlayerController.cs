using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 1.5f;
    [SerializeField] private float jumpForce = 1.5f;
    [SerializeField] private float gravityModifier = 1.5f;
    private float _forceMultiplier = 10f;

    private Rigidbody _rigidbody;
    private bool _onGround = true;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _forceMultiplier *= _rigidbody.mass;
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessMovementInput();
        ProcessJumpInput();
    }

    private void OnCollisionEnter(Collision other)
    {
        _onGround = true;
    }

    private void ProcessMovementInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.forward * Time.deltaTime * moveForce * _forceMultiplier, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(Vector3.back * Time.deltaTime * moveForce * _forceMultiplier, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(Vector3.right * Time.deltaTime * moveForce * _forceMultiplier, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(Vector3.left * Time.deltaTime * moveForce * _forceMultiplier, ForceMode.Impulse);
        }

    }

    private void ProcessJumpInput()
    {
        if (Input.GetKey(KeyCode.Space) && _onGround)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce * _forceMultiplier, ForceMode.Impulse);
            _onGround = false;
        }
    }
}
