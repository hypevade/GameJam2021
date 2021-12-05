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
    //[SerializeField]
    //private GameObject _leftDot;
    //private Rigidbody _leftRb;
    //[SerializeField]
    //private GameObject _rightDot;
    //private Rigidbody _rightRb;
    private bool _isMoveBack;
    private Vector3 _startBackPos;


    void Start()
    {
        _speed = _startSpeed;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = _speed * Vector3.right;
        //_leftRb = _leftDot.GetComponent<Rigidbody>();
        //_rightRb = _rightDot.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.rotation.eulerAngles.y > 150 ||
            transform.rotation.eulerAngles.y < -80)
        {
            if (!_isMoveBack)
                _startBackPos = transform.position;
            _isMoveBack = true;
        }
        else
            _isMoveBack = false;

        if (_isMoveBack && Vector3.Distance(transform.position, _startBackPos) > 1)
        {
            GameIsOver = true;
        }
            
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
