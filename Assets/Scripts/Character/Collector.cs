using System;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    [SerializeField] private Material _collectedBlockMaterial; 
    [SerializeField] private Character _character;
    [SerializeField] private float _duration;

    private float _collectedBlockSizeY;
    private Vector3 _targetRotation;
    
    public event Action<float> Jump;

    private void OnEnable()
    {
        _targetRotation = Vector3.zero;
        _character.BlockCollected += Take;
    }

    private void OnDisable()
    {
        _character.BlockCollected -= Take;
    }

    private void Take(Block block)
    {
        block.transform.SetParent(_character.transform);
        _collectedBlockSizeY = block.BoxCollider.bounds.size.y;
        Jump?.Invoke(_collectedBlockSizeY);
        block.OffCollider();
        block.ChangeMaterial(_collectedBlockMaterial);
        MoveBlock(block);
    }

    private void MoveBlock(Block block)
    {
        block.transform.DOLocalRotate(_targetRotation,_duration);
        block.transform.DOLocalMove(_character.Collector.localPosition, _duration);
    }
}