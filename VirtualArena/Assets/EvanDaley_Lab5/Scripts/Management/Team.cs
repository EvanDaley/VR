using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class Team : MonoBehaviour {

	public int _team = 0;
	private PhotonView m_PhotonView;

	[PunRPC]
	public void SetTeam(int team)
	{
		_team = team;
	}

	void Start()
	{
		InstanceTracker.Instance.Subscribe(this);
	}
}
