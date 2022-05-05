using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerDummy : MonoBehaviour
{
    [SerializeField] private GameObject _playerController;
    private Vector3 _position;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Destroyer"))
        {
            _position = _playerController.transform.position;

            gameObject.transform.position = _position;
        }
    }
}
