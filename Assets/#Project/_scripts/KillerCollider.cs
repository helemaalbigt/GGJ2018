using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillerCollider : MonoBehaviour {

	//public Collider collider;
	public List<string> tags;
	public UnityEvent collisionEvents;

	// Use this for initialization
	void Start () {
		//collider = GetComponent<Collider> ();
	}
	
	void OnCollisionEnter(Collision col) {
		Debug.Log (this.name + " collided with " + col.gameObject + " (" + col.gameObject.tag + ")");
		if (tags.Contains (col.gameObject.tag) || tags.Count == 0) {	// Tags list empty, or the colliding object is in the list
			Debug.Log ("Invoking collision event(s)!");
			if (collisionEvents != null) {
				collisionEvents.Invoke ();
			}
		}
	}
}
