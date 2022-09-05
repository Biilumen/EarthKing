using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _score;

    public int Score => _score;

    public event Action ValueChanged;

    private void Awake()
    {
        _score = 0;
    }

    public void AddScore(int value)
    {
        _score += value;
        ValueChanged?.Invoke();
    }
}