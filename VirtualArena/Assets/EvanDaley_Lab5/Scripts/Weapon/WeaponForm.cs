using UnityEngine;
using System.Collections;

public class WeaponForm : MonoBehaviour {

    public Transform m_rightHandle;
    public Transform m_leftHandle;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public bool isTwoHanded
    {
        get { return m_leftHandle != null; }
    }
}
