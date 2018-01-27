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
    public Material[] CamMaterials;
    public MeshRenderer GameScreen;

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
        string keys = Input.inputString;
        int number;
        if (int.TryParse(keys, out number))
        {
            if (number < Cams.Length)
            {
                for (int i = 0; i < Cams.Length; i++)
                {
                    if (i == number)
                    {
                        Cams[i].Active = true;
                        Material[] mats = GameScreen.materials;
                        mats[0] = CamMaterials[i];
                        GameScreen.materials = mats;
                    }
                    else
                    {
                        Cams[i].Active = false;
                    }
                }
            }
        }
    }
}
