using Assets.Monsters.Scripts.Common;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _transform;
    [SerializeField] private LayerMask _borderLayerMask; 

    [SerializeField] private float _speed = 2f;

    private Vector2 _leftposition;
    private Vector2 _rightposition;

    private bool _isLeft = true;

    private void Start()
    {
        InitComponent();
    }

    private void Update()
    {
        CheckChangeDirection();
    }

    private void FixedUpdate()
    {
        Move(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Trigger Entered: {collision.gameObject.name}");
        if (Misc.IsInLayerMask(collision.gameObject.layer, _borderLayerMask))
            _isLeft = !_isLeft;
    }

    private void CheckChangeDirection()
    {
        if (_isLeft && _transform.position.x <= _leftposition.x)
            _isLeft = false;
        else if (!_isLeft && _transform.position.x >= _rightposition.x)
            _isLeft = true;
    }

    private void Move()
    {
        if (_isLeft)
            _rb.linearVelocity = new Vector2(-_speed, 0);
        else if (!_isLeft)
            _rb.linearVelocity = new Vector2(_speed, 0);

        _transform.localScale = new Vector3(_isLeft ? 1 : -1, 1, 1);
    }

    private void InitComponent()
    {
        // Initialize positions for movement
        _leftposition = new Vector2(transform.position.x - 2f, transform.position.y);
        _rightposition = new Vector2(transform.position.x + 2f, transform.position.y);
    }
}