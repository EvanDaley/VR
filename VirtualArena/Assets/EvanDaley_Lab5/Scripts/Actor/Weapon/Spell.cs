using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PhotonView))]
public class Spell : MonoBehaviour {

	private bool canFire = false;
	private PhotonView m_PhotonView;
	private string spellDNA;
	private Transform m_Transform;

	void Awake () {
		m_Transform = GetComponent<Transform>();
		m_PhotonView = GetComponent<PhotonView>();
	}

	/// <summary>
	/// Initialize this spell (weapon) with the correct DNA. Parse the DNA. Get ready to call the CastSpell RPC.
	/// </summary>
	/// <param name="spellDNA">Spell DN.</param>
	[PunRPC]
	public void Initialize( string spellDNA, int callerID )
	{
		// get data from PhotonView.InstantiationData
		this.spellDNA = spellDNA;
		string color = spellDNA;
		
		Renderer m_Renderer = GetComponentInChildren<Renderer>();
		
		if(color == "Red")
			m_Renderer.material.color = Color.red;
		
		if(color == "White")
			m_Renderer.material.color = Color.white;
		
		if(color == "Green")
			m_Renderer.material.color = Color.green;
		
		if(color == "Blue")
			m_Renderer.material.color = Color.blue;


		PhotonView parentView = PhotonView.Find (callerID);
		m_Transform.SetParent (parentView.transform);

		canFire = true;

	}
	
	// Update is called once per frame
	void Update () {
		if(!canFire)
			return;

		if(m_PhotonView.isMine || !PhotonNetwork.connected)
		{
			// check input
			if(Input.GetButtonDown("Fire1"))
			{
				// create spell on all clients using an rpc

				// try creating a spell with position and rotation
				m_PhotonView.RPC ("Cast",PhotonTargets.All,new object[]{transform.position, transform.rotation});
			}
		}
	}

	// pass position, rotation, prefab, everything necessary to draw the spell on all clients	
	[PunRPC]
	void Cast(Vector3 position, Quaternion rotation)
	{
		// get target vector


		//transform.root.transform.position = position;
		print (position);
	}
}
