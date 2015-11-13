using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class SpikeTrap : MonoBehaviour {

	private Animator m_Animator;
	private StateEnum _state;
	private PhotonView m_PhotonView;

	void Start()
	{
		m_Animator = GetComponent<Animator> ();
		m_PhotonView = GetComponent<PhotonView> ();

		InvokeRepeating ("Toggle",1F,2F);
	}

	void Toggle()
	{
		if(PhotonNetwork.isMasterClient || !PhotonNetwork.connected)
		{
			if(State == StateEnum.active)
			{
				PhotonNetwork.RPC (m_PhotonView,"Lower",PhotonTargets.All,false,new object[]{});
				//State = StateEnum.deactivated;
			}
			else
			{
				PhotonNetwork.RPC (m_PhotonView,"Raise",PhotonTargets.All,false,new object[]{});
				//State = StateEnum.active;
			}
		}
	}
	
	public StateEnum State
	{
		get{ return _state; }
		set
		{
			// activate animator!
			_state = value;
			
			if(_state == StateEnum.active)
			{
				m_Animator.SetBool ("Lowered",false);
			}
			else
			{
				m_Animator.SetBool ("Lowered",true);
			}
		}
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
		State = StateEnum.active;
	}
	
	[PunRPC]
	void Lower()
	{
		State = StateEnum.deactivated;
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
