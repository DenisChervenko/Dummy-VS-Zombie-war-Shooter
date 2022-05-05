using UnityEngine;

public class PlayerController : SimpleInput
{
    [Header("SpeedOption")]
    [SerializeField] private float _speedMove;

    private float _verticalDirection;
    private float _horizontalDirection;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _verticalDirection = SimpleInput.GetAxis("Vertical");
        _horizontalDirection = SimpleInput.GetAxis("Horizontal");

        if(_verticalDirection != 0 || _horizontalDirection != 0)
        {
            _rb.velocity = new Vector3(_horizontalDirection * _speedMove, 0, _verticalDirection * _speedMove);
        }
        else
        {
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }
    }
}
