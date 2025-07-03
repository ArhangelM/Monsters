using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Transform))]
    public partial class Character : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _runSpeedMultiplier = 1.5f;
        [SerializeField] private float _jumpForce = 20f;

        private float _horizontalInput;
        private float _jumpInput;

        private bool _isGrounded = true;
        private bool _isLeft = false;
        private bool _isRun = false;

        private void Update()
        {
            GetInput();
            PlayAnimation();
        }

        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }

        private void GetInput()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _jumpInput = Input.GetAxis("Jump");

            _isRun = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        }

        private void Move()
        {
            Vector2 movement = new Vector2(_horizontalInput * _moveSpeed, _rb.linearVelocityY);
            if (_isRun)
                movement.x *= _runSpeedMultiplier;

            _rb.linearVelocity = movement;

            if(_horizontalInput < 0)
                _isLeft = true;
            else if(_horizontalInput > 0)
                _isLeft = false;

            _transform.localScale = new Vector3(_isLeft ? 1 : -1, 1, 1);
        }

        private void Jump()
        {
            if (_isGrounded && _jumpInput > 0)
            {
                _rb.linearVelocityY = _jumpForce;
                _isGrounded = false;
            }
        }
    }
}