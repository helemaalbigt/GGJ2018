using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameStep : GameStep {

    [Space(25)]
    public TextPrompt _prompt;
    public bool _succes;

    private string msg1 = "Try again?";
    private string msg2 = "Replay";

    public override void StartStep() {
        if (_succes) {
            ShowMsg2();
        }
        else {
            ShowMsg1();
        }
        
    }

    private void ShowMsg1() {
        _prompt.ShowText(msg1, ReloadScene);
    }

    private void ShowMsg2() {
        _prompt.ShowText(msg2, ReloadScene);
    }

    private void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
