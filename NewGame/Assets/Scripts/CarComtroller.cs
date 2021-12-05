using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComtroller : MonoBehaviour
{
    public bool GameIsStarted;
    public bool GameIsPaused;
    public bool GameIsOver;


    private float _speed;
    private Rigidbody _rb;
    [SerializeField]
    private float _startSpeed;
    //[SerializeField]
    //private GameObject _leftDot;
    //private Rigidbody _leftRb;
    //[SerializeField]
    //private GameObject _rightDot;
    //private Rigidbody _rightRb;
    private bool _isMoveBack;
    private Vector3 _startBackPos;
    private float timer = 1f;
    private float tempSpeed;
    private float _angle = 90f;


    void Start()
    {
        _speed = _startSpeed;
        tempSpeed = _startSpeed;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = _speed * Vector3.right;
        //_leftRb = _leftDot.GetComponent<Rigidbody>();
        //_rightRb = _rightDot.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameManager.instance.GameIsPaused && GameManager.instance.GameIsStarted && !GameManager.instance.GameIsOver)
        {
            _speed = tempSpeed;
            _angle = 90f;
        }
        else
        {
            tempSpeed = _speed;
            _speed = 0f;
            _angle = 0f;
        }

        if (transform.rotation.eulerAngles.y > 150 ||
            transform.rotation.eulerAngles.y < -80)
        {
            if (!_isMoveBack)
                _startBackPos = transform.position;
            _isMoveBack = true;
        }
        else
            _isMoveBack = false;

        if (_isMoveBack && Vector3.Distance(transform.position, _startBackPos) > 5)
            GameManager.instance.GameIsOver = true;
            
        if (GameManager.instance.TurnLeft)
        {
            transform.Rotate(0, -_angle, 0);
            _rb.velocity = _speed * transform.forward;
            GameManager.instance.TurnLeft = false;
        }
        if (GameManager.instance.TurnRight)
        {
            transform.Rotate(0, _angle, 0);
            _rb.velocity = _speed * transform.forward;
            GameManager.instance.TurnRight = false;
        }
        _speed += 0.00001f;
        _rb.velocity = _speed * transform.forward;
    }

    private void FixedUpdate()
    {
        if (timer < 0f)
        {
            timer = 1f;
            if (!GameManager.instance.GameIsPaused && GameManager.instance.GameIsStarted && !GameManager.instance.GameIsOver)
                GameManager.instance.GameScore += _speed;
        }
        timer -= Time.deltaTime;
    }
}
