using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComtroller : MonoBehaviour
{
    public bool GameIsStarted;
    public bool GameIsPaused;
    public bool GameIsOver;

    private float _speed = 10f;
    private Rigidbody _rb;
    [SerializeField]
    private float _startSpeed;
    [SerializeField]
    private GameObject _leftDot;
    private Rigidbody _leftRb;
    [SerializeField]
    private GameObject _rightDot;
    private Rigidbody _rightRb;

    void Start()
    {
        _speed = _startSpeed;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = _speed * Vector3.right;
        _leftRb = _leftDot.GetComponent<Rigidbody>();
        _rightRb = _rightDot.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -90f, 0);
            _rb.velocity = _speed * transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 90f, 0);
            _rb.velocity = _speed * transform.forward;
        }
    }
}
