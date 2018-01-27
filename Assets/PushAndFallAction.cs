using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAndFallAction : MonoBehaviour {

	public Vector3 PushVector;
	public float TimeToPush = 1.0f;
	public float DelayBeforePush = 0.5f;
	public Rigidbody _rigidBody;

	void Start () {
		StartCoroutine (Push ());
		_rigidBody = this.GetComponent<Rigidbody> ();
	}
	
	IEnumerator Push() {
		yield return new WaitForSeconds(DelayBeforePush);

		// TODO: Play a sound here

		Vector3 StartPosition = transform.position;
		float StartTime = Time.time;
		float TimeElapsed = 0;

		while (TimeElapsed < TimeToPush) {
			TimeElapsed = Time.time - StartTime;
			transform.position = Vector3.Lerp (StartPosition, StartPosition + PushVector, TimeElapsed / TimeToPush);
			yield return null;
		}

		if (_rigidBody) {
			_rigidBody.useGravity = true;
			_rigidBody.isKinematic = false;
		}
	}
}
