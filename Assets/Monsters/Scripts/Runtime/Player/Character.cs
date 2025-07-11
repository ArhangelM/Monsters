using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Transform))]
    public partial class Character : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Transform _transform;
        [SerializeField] private CollisonScript _horizontalCollison;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _runSpeedMultiplier = 1.5f;
        [SerializeField] private float _jumpForce = 20f;

        private Vector2 _movement;

        private float _horizontalInput;
        private float _jumpInput;

        private bool _isLeft = false;
        private bool _isRun = false;
        private bool _isGround = true;

        private void Update()
        {
            GetInput();
            PlayAnimation();

            _isGround = Physics2D.Raycast(_transform.localPosition, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));        
        }

        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_transform.localPosition, Vector3.down * 1.5f);
        }

        private void GetInput()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _jumpInput = Input.GetAxis("Jump");

            _isRun = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        }

        private void Move()
        {
            if (!_horizontalCollison.IsCollission)
                _movement = new Vector2(_horizontalInput * _moveSpeed, _rb.linearVelocityY);
            else
                _movement = new Vector2(0, _rb.linearVelocityY);

            if (_isRun)
                _movement.x *= _runSpeedMultiplier;

            _rb.linearVelocity = _movement;

            if (_horizontalInput < 0)
                _isLeft = true;
            else if (_horizontalInput > 0)
                _isLeft = false;

            _transform.localScale = new Vector3(_isLeft ? 1 : -1, 1, 1);
        }

        private void Jump()
        {
            if (_isGround && _jumpInput > 0)
            {
                _rb.linearVelocityY = _jumpForce;
                _isGround = false;
            }
        }
    }
}