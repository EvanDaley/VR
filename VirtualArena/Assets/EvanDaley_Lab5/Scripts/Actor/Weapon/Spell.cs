using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PhotonView))]
public class Spell : MonoBehaviour {

	private bool canFire = false;
	private string spellDNA;

	private PhotonView m_PhotonView;
	private Transform m_Transform;
	private Targeting m_Targeting;

	public GameObject targetingIndicatorPrefab;
	private GameObject targetingIndicatorInstance;
	public GameObject attackPrefab;

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

		if (parentView) 
		{
			m_Transform.SetParent (parentView.transform);
			m_Targeting = m_Transform.root.GetComponent<Targeting> ();
			m_Transform.position = parentView.transform.position;

			if(m_Targeting)
			{
				targetingIndicatorInstance = GameObject.Instantiate (targetingIndicatorPrefab, m_Transform.position, m_Transform.rotation) as GameObject;
				print ("Initialize indicator");
			}
		}

		canFire = true;


	}
	
	// Update is called once per frame
	void Update () {
		if(!canFire)
			return;

		if(m_PhotonView.isMine || !PhotonNetwork.connected)
		{
			if (targetingIndicatorInstance)
			{
				if(m_Targeting)
				{
					targetingIndicatorInstance.transform.position = m_Targeting.TargetPoint;

					// check input
					if(Input.GetButtonDown("Fire1"))
					{
						// create spell on all clients using an rpc
						
						// try creating a spell with position and rotation
						m_PhotonView.RPC ("Cast",PhotonTargets.All,new object[]{transform.position, transform.rotation});
					}
				}
				else
				{
					print ("Destroy");
					Destroy (targetingIndicatorInstance);
				}
			}
		}
	}

	// pass position, rotation, prefab, everything necessary to draw the spell on all clients	
	[PunRPC]
	void Cast(Vector3 position, Quaternion rotation)
	{
		GameObject explosion = null;
		// get target vector
		if(attackPrefab != null)
			explosion = GameObject.Instantiate (attackPrefab, m_Targeting.TargetPoint, Quaternion.identity) as GameObject;

		//transform.root.transform.position = position;
		//print (position);
	}
}
