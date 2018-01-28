using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraCollide : MonoBehaviour
{
    public Transform BrokenCamera;
    public UnityEvent OnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollision.Invoke();
        Transform trans = GetComponent<Transform>();
        gameObject.SetActive(false);
        Transform broken = Instantiate<Transform>(BrokenCamera);
        broken.position = trans.position;
        broken.rotation = trans.rotation;
        trans.position = new Vector3(400, 400, Random.value * 400);
    }
}
