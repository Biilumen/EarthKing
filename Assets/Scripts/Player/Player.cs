using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Counter _counter; 
    private Character _character;

    private void Start()
    {
        _character = GetComponent<Character>();
        _counter = GetComponent<Counter>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Block block))
        {
            _counter.AddScore(block.Value);
            _character.CollectedBlock(block);   
        }
    }
}