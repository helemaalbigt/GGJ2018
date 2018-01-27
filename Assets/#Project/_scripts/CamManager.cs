using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    private static CamManager _instance;

    public static CamManager Instance
    {
        get { return _instance; }
    }


    public OperatorCam[] Cams;

    void Start()
    {
        _instance = this;
        Cams[0].Active = true;
        for (int i = 1; i < Cams.Length; i++)
        {
            Cams[i].Active = false;
        }
    }

    void Update()
    {

    }
}
