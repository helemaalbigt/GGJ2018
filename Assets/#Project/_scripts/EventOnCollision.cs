using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollision : MonoBehaviour
{
    public bool OneTime = true;
    public UnityEvent OnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollision.Invoke();
        if (OneTime)
        {
            enabled = false;
        }
    }
}
