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
	    public Transform _target;
		public float fadeInTime = 1f;
		public Color blinkToColor = Color.black;

		void Start() {
			//Teleport ();
		}

		public void Teleport() {

			//VRTK_SDK_Bridge.HeadsetFade(blinkToColor, fadeInTime, true); // Color.clear

		    transform.position = _target.position;
			transform.rotation = _target.rotation;

		}
	}
}
