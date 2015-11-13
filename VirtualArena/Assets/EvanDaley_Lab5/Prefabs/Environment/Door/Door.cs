using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class Door : MonoBehaviour {

	private Animator m_Animator;
	private StateEnum _state;
	private PhotonView m_PhotonView;

	public StateEnum State
	{
		get{ return _state; }
		set
		{
			// activate animator!
			_state = value;

			if(_state == StateEnum.active)
			{
				m_Animator.SetBool ("Lowered",true);
			}
			else
			{
				m_Animator.SetBool ("Lowered",false);
			}
		}
	}

	void Start()
	{
		m_Animator = GetComponent<Animator> ();
		m_PhotonView = GetComponent<PhotonView> ();
	}

	void Update()
	{
		if(PhotonNetwork.inRoom)
		{
			if (Input.GetButtonDown ("Fire1")) 
			{
				PhotonNetwork.RPC (m_PhotonView,"Raise",PhotonTargets.All,false,new object[]{});
			}

			if (Input.GetButtonDown ("Fire2")) 
			{
				PhotonNetwork.RPC (m_PhotonView,"Lower",PhotonTargets.All,false,new object[]{});
			}
		}
		else
		{
			if (Input.GetButtonDown ("Fire1")) 
			{
				Raise ();
			}

			if (Input.GetButtonDown ("Fire2")) 
			{
				Lower ();
			}
		}
	}

	[PunRPC]
	void Raise()
	{
		State = StateEnum.deactivated;
	}

	[PunRPC]
	void Lower()
	{
		State = StateEnum.active;
	}

	[PunRPC]
	void PowerOn()
	{

	}

	[PunRPC]
	void PowerOff()
	{

	}
}
