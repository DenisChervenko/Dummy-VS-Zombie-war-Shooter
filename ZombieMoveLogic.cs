using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoveLogic : MonoBehaviour
{
    [Header("SpeedOption")]
    [SerializeField] private float _speedMoveFaster;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        _rb.velocity = new Vector3(0, 0, _speedMoveFaster * Time.fixedDeltaTime);
    }
}
