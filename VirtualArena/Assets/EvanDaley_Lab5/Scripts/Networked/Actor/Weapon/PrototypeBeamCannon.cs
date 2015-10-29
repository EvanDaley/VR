using UnityEngine;
using System.Collections;

public class PrototypeBeamCannon : MonoBehaviour {

	private Animator m_Anim;
	public string handPosition;

	// Use this for initialization
	void Start () {
		Equip ();
	}

	void Equip()
	{
		// disable physics so the weapon doensn't push things

		// attach to hand

		// set hand to the right animation / position
		m_Anim = transform.root.GetComponent<Animator>();
		m_Anim.Play(handPosition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
