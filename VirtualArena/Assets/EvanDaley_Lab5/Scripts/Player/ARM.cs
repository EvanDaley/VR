using UnityEngine;
using System.Collections;

public class ARM : MonoBehaviour {

    private Targeting m_Targeting;
    private Transform target1;
    public bool createTargetingScript;

    void Start() {
        m_Targeting = GetComponentInChildren<Targeting>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (m_Targeting)
                target1 = m_Targeting.Target;
            else
            {
                print("Couldn't locate targeting script");

                if (createTargetingScript)
                {
                    m_Targeting = Camera.main.gameObject.AddComponent<Targeting>();
                }
            }
        }

        if(target1 != null)
        {
            if(target1.tag == "Dynamic")
                target1.SetParent(m_Targeting.gameObject.transform);
        }
	}
}
