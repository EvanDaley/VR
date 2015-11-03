using UnityEngine;
using System.Collections;

/// <summary>
/// Only use this on characters that NEED to be in the PERFECTLY synchronized positions. 
/// ThirdPersonCharacterSinc usually works with .1 to .4 meters accuracy and causes less
/// network traffic.
/// </summary>
public class CharacterPositionSync : MonoBehaviour {

	PhotonView photonView;
	Vector3 actualPosition;

	// Use this for initialization
	void Start () {
		photonView = GetComponent<PhotonView> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (photonView.isMine)
			photonView.RPC ("BroadcastPosition", PhotonTargets.Others, transform.position);

		else {
			float distance = Vector3.Distance (actualPosition, transform.position);
			if (distance > .15f) {
				//we want to lerp quickly if the character is way out of sync and 
				//slowly if they are relatively close to where they shoul be
				float jumpDistance = distance/10;
				Vector3 next = Vector3.Lerp (transform.position,actualPosition,jumpDistance);
				transform.position = next;
				//print (gameObject.name + " nudged (" + next + ")");
			}
		}
	}

	[RPC]
	void BroadcastPosition(Vector3 actualPosition)
	{
		this.actualPosition = actualPosition;
	}
}
