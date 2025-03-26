using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float _speed=3.5f, _jumpForce=6.0f;
    private Vector3 _dir;
    private Rigidbody _rb;

    private KeyCode _keyJump=KeyCode.Space;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.z = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(_keyJump))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        if (_dir.sqrMagnitude!=0.0f)
        {
            _rb.MovePosition(transform.position + (_dir.normalized * _speed * Time.fixedDeltaTime));
        }
    }
    private void Jump()
    {
        _rb.AddForce(transform.up*_jumpForce,ForceMode.Impulse);
    }
}
