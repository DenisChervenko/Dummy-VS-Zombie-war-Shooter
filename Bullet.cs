using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector3(0, 0, _speedMove * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Zombie") || other.gameObject.CompareTag("LeftSide") || other.gameObject.CompareTag("RightSide"))
        {
            gameObject.SetActive(false);
        }
    }
}
