using UnityEngine;
using System.Collections;

public class WeaponForm : MonoBehaviour {

    public Transform m_rightHandle;
    public Transform m_leftHandle;

    private Targeting m_Targeting;
    private Transform m_Transform;

	// Use this for initialization
	void Start () {
        m_Transform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Targeting != null)
        {
            // Get target
            Vector3 lookTarget = m_Targeting.RayHitPoint;

            // Update rotation
            //m_Transform.rotation = transform.rota
        }
	}

    void Activate(Targeting targeting)
    {
        m_Targeting = targeting;
    }

    void Deactivate()
    {
        m_Targeting = null;
    }

    public bool isTwoHanded
    {
        get { return m_leftHandle != null; }
    }
}
