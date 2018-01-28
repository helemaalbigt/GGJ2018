using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitchTutorial : MonoBehaviour
{
    public GameObject tutorialText;

    private bool pressed;

	void Start () {
	    StartCoroutine(Blink());
	}

    void Update() {
        if (Input.GetKey(KeyCode.Alpha2))
            pressed = true;
    }

    IEnumerator Blink() {
        while(!pressed) {
            yield return new WaitForSeconds(.75f);
            tutorialText.SetActive(false);
            yield return new WaitForSeconds(.75f);
            tutorialText.SetActive(true);
        }

        tutorialText.SetActive(true);
    }
}
