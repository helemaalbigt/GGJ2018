using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class GameStep : MonoBehaviour
{
    public event Action onActionComplete; 

    public bool isFirstStep;
    public GameStep nextStep;

    void Start() {
        if (isFirstStep) 
            StartStep();
    }

    public abstract void StartStep();

    public void Next() {
        if (onActionComplete != null)
            onActionComplete();

        Debug.Log("Step Complete: "+name);

        if (nextStep != null)
            nextStep.StartStep();
    }
}
