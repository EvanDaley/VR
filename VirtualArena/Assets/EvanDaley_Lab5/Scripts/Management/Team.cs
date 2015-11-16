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

	/// <summary>
	/// Gets or sets this objects team ID (switch teams, find out what team we are on, numbers 1-9)
	/// </summary>
	/// <value>The ID.</value>
	public int ID
	{
		set
		{
			_team = value;
			// call rpc
		}

		get
		{
			return _team;
		}
	}

	void Start()
	{
		InstanceTracker.Instance.Subscribe(this);
	}
}
