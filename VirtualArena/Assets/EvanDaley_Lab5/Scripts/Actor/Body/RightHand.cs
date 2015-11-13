using UnityEngine;
using System.Collections;

public class RightHand : MonoBehaviour {

	public string[] spellList;
	private GameObject activeSpell;
	private string spellDNA;

	private Transform m_Transform;
	private PhotonView m_PhotonView;
	private PhotonView m_SpellView;

	void Awake()
	{
		m_Transform = GetComponent<Transform>();
		m_PhotonView = GetComponent<PhotonView>();
		SpellIndex = 1;
	}

	void Update()
	{
		if(m_PhotonView.isMine || (m_PhotonView.isSceneView && PhotonNetwork.isMasterClient) || PhotonNetwork.offlineMode || !PhotonNetwork.connected)
		{
				 if(Input.GetKeyDown (KeyCode.Alpha1))	SpellIndex = 0;
			else if(Input.GetKeyDown (KeyCode.Alpha2))	SpellIndex = 1;
			else if(Input.GetKeyDown (KeyCode.Alpha3))	SpellIndex = 2;
			else if(Input.GetKeyDown (KeyCode.Alpha4))	SpellIndex = 3;
			else if(Input.GetKeyDown (KeyCode.Alpha5))	SpellIndex = 4;
			else if(Input.GetKeyDown (KeyCode.Alpha6))	SpellIndex = 5;
			else if(Input.GetKeyDown (KeyCode.Alpha7))	SpellIndex = 6;
			else if(Input.GetKeyDown (KeyCode.Alpha8))	SpellIndex = 7;
			else if(Input.GetKeyDown (KeyCode.Alpha9))	SpellIndex = 8;
			else if(Input.GetKeyDown (KeyCode.Alpha0))	SpellIndex = 9;
		}
	}

	private int SpellIndex
	{
		set
		{
			if(value <= spellList.Length - 1)
			{
				spellDNA = spellList[value];
				print ("Creating Spell with DNA: " + spellDNA);
				
				if(m_PhotonView.isMine)
					CreateSpell ();
			}
		}
	}

	void OnPhotonPlayerConnected()
	{
		if(m_PhotonView.isMine)
		{
			if(m_SpellView)
				m_SpellView.RPC ("Initialize",PhotonTargets.All,new object[]{ spellDNA, m_PhotonView.viewID });
		}
	}

	public void CreateSpell()
	{
		if(activeSpell)
		{
			DestroyPrev(activeSpell);
		}
			
		activeSpell = PhotonNetwork.Instantiate ("Spell", m_Transform.position, m_Transform.rotation, 0);

		// Get the PhotonView of the new spell
		m_SpellView = activeSpell.GetComponent<PhotonView>();
		if(m_SpellView)
			m_SpellView.RPC ("Initialize",PhotonTargets.All,new object[]{ spellDNA, m_PhotonView.viewID });
	}

	public void DestroyPrev(GameObject previousSpell)
	{
		PhotonNetwork.Destroy(previousSpell);
	}
	
}
