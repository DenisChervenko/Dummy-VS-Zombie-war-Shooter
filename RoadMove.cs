using UnityEngine;

public class RoadMove : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    NumAtRoad numAtRoad;

    private Rigidbody _rb;

    [SerializeField] private bool _startPlatform = false;

    private void Start()
    {
        if(!_startPlatform)
        {
            numAtRoad = gameObject.GetComponent<NumAtRoad>();
        }
        
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveRoad();
    }

    private void MoveRoad()
    {
        _rb.velocity = new Vector3(0, 0, _speedMove * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RoadDestroyer"))
        {
            if(!_startPlatform)
            {
                numAtRoad.ActiveSomePartRoad();
            }
            
            gameObject.SetActive(false);
        }
    }
}
