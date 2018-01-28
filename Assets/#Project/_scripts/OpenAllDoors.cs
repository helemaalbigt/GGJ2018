using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAllDoors : MonoBehaviour {

	public GameObject[] AllDoors;

	// Use this for initialization
	void Start () {
		//PrisonBreak ();
	}
	
	public void PrisonBreak() {
		StartCoroutine (_PrisonBreak ());
	}

	IEnumerator _PrisonBreak() {
		AllDoors = GameObject.FindGameObjectsWithTag ("Door");

		foreach (GameObject door in AllDoors) {
			PushAction doorPushAction = door.GetComponent<PushAction> ();
			if (doorPushAction != null) {
				doorPushAction.Push ();
				yield return new WaitForSeconds (Random.value * 0.2f);
			} else {
				Debug.Log ("No push action found on: " + door.name);
			}
		}
	}
}
