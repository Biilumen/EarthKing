using System;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    [SerializeField] private List<Transform> _blocks;
    
    private Transform _closest;

    public Transform GetClosestTarget(Transform enemyTransform)
    {
        if (!enemyTransform.TryGetComponent(out Enemy enemy))
            throw new NullReferenceException(nameof(transform));

        float distance = Mathf.Infinity;
        foreach (Transform block in _blocks)
        {
            Vector3 direction = block.position - enemyTransform.position;
            float curentDistanse = direction.sqrMagnitude;
            if (curentDistanse < distance)
            {
                _closest = block;
                distance = curentDistanse;
            }
        }
        return _closest;
    }

    public void RemoveBlock(Transform block)
    {
        if (!block.TryGetComponent(out Block block1))
            throw new ArgumentOutOfRangeException(nameof(block));

        _blocks.Remove(block);
    }
}