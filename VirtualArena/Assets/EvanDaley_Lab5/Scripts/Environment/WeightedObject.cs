using UnityEngine;
using System.Collections;

public class WeightedObject : MonoBehaviour {

    float mass = 35;

    Rigidbody m_rbody;

    void Start()
    {
        m_rbody = GetComponent<Rigidbody>();

        if(m_rbody)
        {
            mass = m_rbody.mass;
        }
    }
}
