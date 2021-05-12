using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class RoboMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private ContactFilter2D _contactFilter;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider;
    private RaycastHit2D[] _hit2D = new RaycastHit2D[1];
    private Color _rayColor;

    private float _additionDistance = 0.1f;
    private Vector2 _jumpForce;
    private Vector3 _leftDirection;
    private Vector3 _rightDirection;
    private float _currentSpeed;
    private float _accelerationFactor = 1.8f;
    private bool _doubleJump;
    private bool _isMoving;
    private Coroutine _movingJob;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();

        _rightDirection = transform.localScale;
        _leftDirection = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void Moving(bool isRightDirection)
    {
        if (_movingJob != null)
            StopCoroutine(_movingJob);

        _movingJob = StartCoroutine(MovingJob(isRightDirection));
    }

    public void Running()
    {
        _currentSpeed = _speed * _accelerationFactor;
    }

    public void StopMovement()
    {
        _isMoving = false;
        _currentSpeed = _speed;

        if (_movingJob != null)
            StopCoroutine(_movingJob);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            Jumping();
            _doubleJump = true;
        }
        else if (!IsGrounded() && _doubleJump)
        {
            Jumping();
            _doubleJump = false;
        }
    }

    private void Jumping()
    {
        _jumpForce = new Vector2(0, _jumpPower + _currentSpeed);
        _rigidbody2D.AddForce(_jumpForce);
    }

    private bool IsGrounded()
    {
        int countHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, _contactFilter, _hit2D, _additionDistance);

        if (countHit > 0)
            _rayColor = Color.red;

        else
            _rayColor = Color.green;

        Debug.DrawRay(_collider.bounds.center - new Vector3(_collider.bounds.extents.x, _collider.bounds.extents.y + _additionDistance), Vector2.right * (_collider.bounds.extents.x), _rayColor);

        return countHit > 0;
    }

    private IEnumerator MovingJob(bool isRightDirection)
    {
        _isMoving = true;

        while (_isMoving)
		{
            if (isRightDirection)
			{
                transform.localScale = _rightDirection;

                transform.Translate(_currentSpeed * Time.deltaTime, 0, 0);
            }
			else
			{
                transform.localScale = _leftDirection;

                transform.Translate(-1 * _currentSpeed * Time.deltaTime, 0, 0);
            }
            
            yield return null;
        }
    }
}
