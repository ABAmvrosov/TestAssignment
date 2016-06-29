using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool IsGrounded { get; set; }
    public bool IsMoving {
        get { return _isMoving; }
        set {
            _isMoving = value;
            if (value)
                StartCoroutine(StartMovement());
            else
                StopCoroutine("StartMovement");
        }
    }
    private bool _isMoving;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;

    private void Awake() {
        IsGrounded = true;
        _rigidbody = GetComponent<Rigidbody>();
        _wait = new WaitForSeconds(0.1f);
        Messenger.AddListener("Jump", Jump);
        Messenger.AddListener("Move", Move);
    }

    private void Jump() {
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    private void Move() {
        IsMoving = true;
    }

    private IEnumerator StartMovement() {
        while (IsMoving) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);
            _rigidbody.AddForce(movement * _speed);
            if (_rigidbody.velocity.magnitude > _maxSpeed)
                _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
            yield return null;
        }
    }
}
