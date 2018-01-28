using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorCam : MonoBehaviour
{
    protected const float InactiveWidth = 0.3f;

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

            cam.gameObject.SetActive(value);
            /*ScreenSpace
            if (_active)
            {
                float height = (1 - InactiveWidth) * aspect;
                float yOffset = (1 - height) / 2;
                cam.rect = new Rect(0, yOffset, 1 - InactiveWidth, height);
            }
            else
            {
                float height = InactiveWidth * aspect;
                float yOffset = 0.5f+height * (CamManager.Instance.Cams.Length-2)/2f-height*Slot;
                cam.rect = new Rect(1 - InactiveWidth, yOffset, InactiveWidth, height);
            }
            */
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

        aspect = 3.5f/4f*Screen.width/Screen.height;
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
