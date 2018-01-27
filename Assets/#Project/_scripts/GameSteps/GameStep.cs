using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStep : MonoBehaviour
{
    public abstract void StartStep();

    public void GoToStep(GameStep step) {
        step.StartStep();
    }
}
