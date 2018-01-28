using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushAction : MonoBehaviour {

	public Vector3 PushVector;
	public Vector3 PushRotation;

	public UnityEvent PushCompletedEvents;

	public float TimeToPush = 1.0f;
	public float DelayBeforePush = 0.5f;
	public bool EnableGravityAfterPush = true;

    public bool pushOnAwake;

	private Rigidbody _rigidBody;

	void Start () {
		_rigidBody = this.GetComponent<Rigidbody> ();
        if(pushOnAwake)
            Push();
	}

	public void Push() {
		StartCoroutine (_Push());
	}

	IEnumerator _Push() {
		yield return new WaitForSeconds(DelayBeforePush);

		// TODO: Play a sound here

		Vector3 StartPosition = transform.position;
		Vector3 EndPosition = StartPosition + PushVector;
		Quaternion StartRotation = transform.rotation;
		Quaternion EndRotation = StartRotation * Quaternion.Euler(PushRotation);

		float StartTime = Time.time;
		float TimeElapsed = 0;

		while (TimeElapsed < TimeToPush) {
			TimeElapsed = Time.time - StartTime;
			transform.position = Vector3.Lerp (StartPosition, EndPosition, TimeElapsed / TimeToPush);
			transform.rotation = Quaternion.Lerp(StartRotation, EndRotation, TimeElapsed / TimeToPush);
			yield return null;
		}

		if (_rigidBody && EnableGravityAfterPush) {
			_rigidBody.useGravity = true;
			_rigidBody.isKinematic = false;
		}

		if (PushCompletedEvents != null) {
			PushCompletedEvents.Invoke ();
		}
	}
}
