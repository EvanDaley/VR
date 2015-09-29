using UnityEngine;
using System.Collections;

public class ARMHandleControl : MonoBehaviour {

    private Targeting m_Targeting;

    // Use this for initialization
    void Start()
    {
        m_Targeting = GetComponent<Targeting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Targeting.Target != null)
        {
            ARMHandle.Instance.gameObject.transform.position = m_Targeting.RayHitPoint;
        }
        else
        {
            //print("Target == null");
            ARMHandle.Instance.gameObject.transform.position = (Camera.main.transform.position + Camera.main.transform.forward * m_Targeting.recentDistance);
        }
    }
}
