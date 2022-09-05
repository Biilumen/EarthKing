using System;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class Character : MonoBehaviour
{
    private const string Jump = nameof(Jump);

    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Transform _collector;
    [SerializeField] private GameObject _crown;
    [SerializeField] private string _nametext;
    [SerializeField] private Animator _animator;

    private string _name;
    private Counter _counter;
    private Color _color;
    private bool _isAlive;
    private int _kills;

    public int Kills => _kills;
    public GameObject Crown => _crown;
    public Transform Collector => _collector;
    public Color Color => _color;
    public string Name => _name;
    public bool IsAlive => _isAlive;
    public int Score => _counter.Score;

    public event Action UpdateKillboard;
    public event Action ScoreChange;
    public event Action<Block> BlockCollected;

    private void Awake()
    {
        _name = _nametext;
        _kills = 0;
        _counter = GetComponent<Counter>();
        _color = _skinnedMeshRenderer.material.color;
        _isAlive = true;
    }

    private void OnEnable()
    {
        _counter.ValueChanged += LeaderboardRefresh;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= LeaderboardRefresh;
    }


    private void LeaderboardRefresh()
    {
        ScoreChange?.Invoke();
    }
    public void AddKill()
    {
        _animator.SetTrigger(Jump);
        _kills++;
        UpdateKillboard?.Invoke();
    }

    public void Die()
    {
        _isAlive = false;
        gameObject.SetActive(false);
        ScoreChange?.Invoke();
    }

    public void CollectedBlock(Block block)
    {
        BlockCollected?.Invoke(block);
        _animator.SetTrigger(Jump);
    }

    public void AddScore(int value)
    {
        _counter.AddScore(value);
    }
}
