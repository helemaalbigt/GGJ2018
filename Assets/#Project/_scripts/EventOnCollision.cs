using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollision : MonoBehaviour
{
    public bool OneTime = true;
    public UnityEvent OnCollision;

    public bool Done;

    private void OnCollisionEnter(Collision collision)
    {
        if (!OneTime||(OneTime&&!Done))
        {
            OnCollision.Invoke();
        }
        if (OneTime)
        {
            Done = true;
        }
    }
    public void ResetEvent()
    {
        Done = false;
    }
}
