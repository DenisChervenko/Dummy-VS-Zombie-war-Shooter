using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallButton : MonoBehaviour
{
    public bool _callAllUnit = false;

    public void OnClickDownCall()
    {
        _callAllUnit = true;
    }

    public void OnClickUpCall()
    {
        _callAllUnit = false;
    }
}
