using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStep : MonoBehaviour
{
    public bool isFirstStep;
    public GameStep nextStep;

    void Start() {
        if (isFirstStep) 
            StartStep();
    }

    public abstract void StartStep();

    public void Next() {
        if(nextStep != null)
            nextStep.StartStep();
    }
}
