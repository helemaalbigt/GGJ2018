using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorCam : MonoBehaviour
{
    protected const float InactiveWidth = 0.2f;

    private bool _active;
    public bool Active
    {
        get
        {
            return _active;
        }
        set
        {
            _active = value;

            //ScreenSpace
            if (_active)
            {
                float height = (1 - InactiveWidth) * aspect;
                float yOffset = (1 - height) / 2;
                cam.rect = new Rect(0, yOffset, 1 - InactiveWidth, height);
            }
            else
            {
                float height = InactiveWidth * aspect;
                float yOffset = 0;
                cam.rect = new Rect(1 - InactiveWidth, 0, InactiveWidth, height);
            }
        }
    }
    public int Slot;
    public float FOVMax;
    public float FOVMin;
    public float FOVSpeed;

    protected Transform trans;
    protected Camera cam;

    private float aspect; //H/W

    protected virtual void Start()
    {
        trans = GetComponent<Transform>();
        cam = trans.GetComponentInChildren<Camera>();

        aspect = 1080f / 1920f;
    }

    protected virtual void Update()
    {
        if (Active)
        {
            float fovDelta = Input.mouseScrollDelta.y * FOVSpeed;
            //Add limiters

            cam.fieldOfView -= fovDelta;
        }
    }
}
