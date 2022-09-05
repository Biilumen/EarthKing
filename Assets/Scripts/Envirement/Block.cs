using System;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private Earth _earth;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private MeshRenderer _meshRenderer;

    private BoxCollider _boxCollider;
    private Vector3 _size;
    private int _value;

    public BoxCollider BoxCollider => _boxCollider;
    public Vector3 Size => _size;
    public int Value => _value;
    public Transform EndPoint => _endPoint;


    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _size = _boxCollider.bounds.size;
        _value = 1;
    }

    private void OnTriggerEnter(Collider collider)
    {
        _earth.RemoveBlock(this.transform);
    }

    public void ChangeMaterial(Material material)
    {
        _meshRenderer.material = material;
    }

    public void OffCollider()
    {
        _boxCollider.enabled = false;
    }
}