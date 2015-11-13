using UnityEngine;
using System.Collections;

public class StickToHand : MonoBehaviour {

	[PunRPC]
	public void SetHand(Transform hand)
	{
		transform.SetParent(hand);
	}
}
