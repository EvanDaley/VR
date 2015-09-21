using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkBackdoor : MonoBehaviour {

    private NetworkManager m_NetworkManager;

	// Use this for initialization
	void Start () {
        m_NetworkManager = GetComponent<NetworkManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.C))
        {
            if(!m_NetworkManager.isNetworkActive)
                m_NetworkManager.StartClient();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!m_NetworkManager.isNetworkActive)
                m_NetworkManager.StartHost();
        }
    }
}
