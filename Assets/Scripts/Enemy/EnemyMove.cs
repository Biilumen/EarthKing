using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Collector))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Enemy _enemy;
    private Transform _collectorPosition;
    private Collector _collector;
    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _collector = GetComponent<Collector>();
        _enemy = GetComponent<Enemy>();
        _collectorPosition = _character.Collector.transform;
    }

    private void OnEnable()
    {
        _collector.Jump += Jump;
    }

    private void OnDisable()
    {
        _collector.Jump -= Jump;
    }

    private void Update()
    {
        if (_enemy.Target == null)
            return;
        else
            Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_enemy.Target.position.x, transform.position.y, _enemy.Target.position.z), _speed * Time.deltaTime);
        transform.DOLookAt(_enemy.Target.position, _rotationSpeed, AxisConstraint.Y,Vector3.up);
    }

    private void Jump(float height)
    {
        transform.position = transform.position + new Vector3(0f, height, 0f);
        _collectorPosition.position = _collectorPosition.position - new Vector3(0f, height, 0f);
    }
}