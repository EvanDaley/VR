using UnityEngine;
using System.Collections;

public class RightHand : MonoBehaviour {

	/// <summary>
	/// The animation parameter that will determine which animation to play. 
	/// </summary>
	public string animParm = "Throw";

	/// <summary>
	/// The animator component.
	/// </summary>
	private Animator m_Anim;

	void Start () {
		m_Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//m_Anim.SetBool(animParm, false);

		if(Input.GetButtonDown("Fire2"))
		{
			//m_Anim.SetBool(animParm, true);
			m_Anim.Play(animParm);
		}
	}
}
