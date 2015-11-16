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

	public float coolOff = 0;
	public float fireRate = .1F;
	private bool rapidFire = true;

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
		// Connect to the hand that spawned this spell and cache components
		CallBackToHand (callerID);

		// Configure components based on spell DNA
		ConfigureSelf (spellDNA);

		canFire = true;
	}

	void CallBackToHand(int callerID)
	{
		PhotonView parentView = PhotonView.Find (callerID);
		
		if (parentView) {
			m_Transform.SetParent (parentView.transform);
			m_Targeting = m_Transform.root.GetComponent<Targeting> ();
			m_Transform.position = parentView.transform.position;
			
			if (m_Targeting) {
				targetingIndicatorInstance = GameObject.Instantiate (targetingIndicatorPrefab, m_Transform.position, m_Transform.rotation) as GameObject;
				print ("Initialize indicator");
			}
		} else {
			print ("Could not find parent when creating spell (weapon). Destroying spell.");
			PhotonNetwork.Destroy (this.gameObject);
		}
	}

	/// <summary>
	/// Configures the spell based on its DNA. 
	/// </summary>
	/// <param name="spellDNA">Spell DN.</param>
	void ConfigureSelf(string spellDNA)
	{
		// should take into account 
		// 1. attack type
		// 2. fire rate
		// 3. rapid fire (can they hold down the mouse button?)
		// 4. area of effect
		// 5. targeting indicator
		// 6. attack prefab
		// 7. damage
		// 8. damage type
		// 9. effect list
		// 10. spell lifetime

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
	}

	private void TryFire()
	{
		if (coolOff < 0) 
		{
			// create spell on all clients using an rpc
			//m_PhotonView.RPC ("Cast", PhotonTargets.All, new object[]{transform.position, transform.rotation});

			//m_PhotonView.RPC ("Cast", PhotonTargets.All, new object[]{m_Targeting.TargetPoint, transform.rotation, Vector3.zero});

			Vector3 direction = m_Targeting.TargetPoint - transform.position;

			m_PhotonView.RPC ("Cast", PhotonTargets.All, new object[]{transform.position + transform.forward*2, transform.rotation, direction * 100});


			coolOff = fireRate;
		}
	}

	// pass position, rotation, prefab, everything necessary to draw the spell on all clients	
	[PunRPC]
	void Cast(Vector3 position, Quaternion rotation, Vector3 directionForce)
	{
		GameObject attack = null;
		// get target vector
		if(attackPrefab != null)
			attack = GameObject.Instantiate (attackPrefab, position, rotation) as GameObject;

		Rigidbody body = attack.GetComponent<Rigidbody> ();
		if (body)
			body.AddForce (directionForce);
		
		//transform.root.transform.position = position;
		//print (position);
	}

	// Update is called once per frame
	void Update () {
		if(!canFire)
			return;

		coolOff -= Time.deltaTime;

		if(m_PhotonView.isMine || !PhotonNetwork.connected)
		{
			if (targetingIndicatorInstance)
			{
				if(m_Targeting)
				{
					targetingIndicatorInstance.transform.position = m_Targeting.TargetPoint;

					// check input 
					if((Input.GetButton("Fire2") && rapidFire) || Input.GetButtonDown("Fire2"))
					{
						TryFire();
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
}
