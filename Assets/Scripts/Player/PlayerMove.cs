using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _collectorPosition;

    private Rigidbody _rigidbody;
    private Collector _collector;

    private void Awake()
    {
        _collector = GetComponent<Collector>(); 
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _collector.Jump += Jump;
    }

    private void OnDisable()
    {
        _collector.Jump -= Jump;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move ()
    {
        Vector3 direction = new Vector3(_joystick.Horizontal * -1, 0f, _joystick.Vertical * -1) * _speed;
        direction = Vector3.ClampMagnitude(direction, _speed);

        if (direction != Vector3.zero)
        {
            _rigidbody.MovePosition(transform.position + direction * Time.deltaTime);
            _rigidbody.MoveRotation(Quaternion.LookRotation(direction));
        }
    }

    private void Jump(float height)
    {
        transform.position = transform.position + new Vector3(0f, height, 0f);
        _collectorPosition.position = _collectorPosition.position - new Vector3(0f, height, 0f);
    }
}