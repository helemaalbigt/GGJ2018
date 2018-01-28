// Basic Teleport|Locomotion|20010
namespace VRTK
{
	using UnityEngine;
	using System.Collections;
	#if UNITY_5_5_OR_NEWER
	using UnityEngine.AI;
	#endif

	[AddComponentMenu("VRTK/Scripts/Locomotion/TeleportPrisoner")]
	public class TeleportPrisoner : MonoBehaviour
	{
		public Vector3 _destinationPosition;
		public Vector3 _destinationRotation;
		public float fadeInTime = 1f;
		public Color blinkToColor = Color.black;

		void Start() {
			//Teleport ();
		}

		public void Teleport() {
			Debug.Log ("Teleporting player to: " + _destinationPosition);

			//VRTK_SDK_Bridge.HeadsetFade(blinkToColor, fadeInTime, true); // Color.clear

			transform.position = _destinationPosition;
			transform.rotation = Quaternion.Euler(_destinationRotation);

		}
	}
}
