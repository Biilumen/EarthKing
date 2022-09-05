using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _reward;

    private Earth _earth;
    private Transform _target;
    private Counter _counter;
    private Character _character;

    public Transform Target => _target;

    private void Start()
    {
        _character = GetComponent<Character>();
        _counter = GetComponent<Counter>();
        _earth = FindObjectOfType<Earth>();
        GetTarget();
    }

    private void Update()
    {
        if (_target!=null)
            return;
        else
            GetTarget();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Block block))
        {
            _counter.AddScore(block.Value);
            _character.CollectedBlock(block);
            GetTarget();
        }
        else if (collider.TryGetComponent(out Character character))
        {
            if (_character.Score > character.Score)
            {
                _character.AddScore(_reward);
                _character.AddKill();
                character.Die();
            }
            else
            {
                character.AddScore(_reward);
                character.AddKill();
                _character.Die();
            }
        }
    }

    private void GetTarget()
    {
        _target = _earth.GetClosestTarget(transform);
    }
}