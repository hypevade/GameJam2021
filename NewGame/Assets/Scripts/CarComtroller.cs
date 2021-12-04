using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComtroller : MonoBehaviour
{
    private bool isRight = true;
    private float _speed = 10f;
    private Rigidbody _rb;
    [SerializeField]
    private float _startSpeed;

    void Start()
    {
        _speed = _startSpeed;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = _speed * Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && isRight)
        {
            transform.rotation = new Quaternion();
            isRight = false;
        }
        if(Input.GetKey(KeyCode.RightArrow) && !isRight)
        {
            _rb.velocity = _speed * Vector3.right;
            isRight = true;
        }
    }
}
