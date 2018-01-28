using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountedCam: OperatorCam
{
    public AudioClip MovingSound;
    public AudioClip StopSound;
    public float XMax;
    public float XMin;
    public float YMax;
    public float YMin;
    public float Speed;

    private AudioSource audio;
    private Vector3 angleDiffs;
    private bool wasMoving;

    protected override void Start()
    {
        base.Start();
        audio = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        if (Active)
        {
            Vector3 dif = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftArrow) && angleDiffs.y > YMin)
            {
                dif.y -= Speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow) && angleDiffs.y < YMax)
            {
                dif.y += Speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow) && angleDiffs.x > XMin)
            {
                dif.x -= Speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow) && angleDiffs.x < XMax)
            {
                dif.x += Speed * Time.deltaTime;
            }
            angleDiffs += dif;
            trans.Rotate(dif.x, 0, 0, Space.Self);
            trans.Rotate(0, dif.y, 0, Space.World);

            bool moving = dif != Vector3.zero;
            if (moving&&!wasMoving)
            {
                audio.clip = MovingSound;
                audio.loop = true;
                audio.Play();
            }
            else
            {
                if (wasMoving&&!moving)
                {
                    audio.clip = StopSound;
                    audio.loop = false;
                    audio.Play();
                }
            }
            wasMoving = moving;
            
        }
        base.Update();
    }
}
