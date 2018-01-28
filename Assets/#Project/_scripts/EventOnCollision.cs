using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollision : MonoBehaviour
{
    public bool OneTime = true;
    public UnityEvent OnCollision;

    private bool done;

    private void OnCollisionEnter(Collision collision)
    {
        if (!OneTime||(OneTime&&!done))
        {
            OnCollision.Invoke();
        }
        if (OneTime)
        {
            done = true;
        }
    }
    public void ResetEvent()
    {
        done = false;
    }
}
