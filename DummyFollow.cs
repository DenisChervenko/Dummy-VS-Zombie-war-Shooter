using UnityEngine;

public class DummyFollow : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    [SerializeField] private GameObject _callButton;
    CallButton call;

    private Transform _target;

    private void Start()
    {
        _target = GameObject.Find("PlayerContoller").transform;
        call = _callButton.GetComponent<CallButton>();
    }

    private void FixedUpdate()
    {
        if(call._callAllUnit)
        {
            Vector3 target = _target.transform.position;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, _speedMove * Time.fixedDeltaTime);
        }

        Move();
    }

    private void Move()
    {
        Vector3 target = _target.transform.position;

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, _speedMove * Time.fixedDeltaTime);
    }


}
