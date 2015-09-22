using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class PlayerSwitcher : MonoBehaviour {

    public GameObject normalPlayer;
    public GameObject riftPlayer;

    void Update () {
	    if(LocalSettings.instance.autoDetectRift)
        {
            if (VRDevice.isPresent) {
                UseRift();
            } else {
                UseNormal();
            }
        }
    }

    public void UseRift()
    {
        // Disable Normal Camera
        normalPlayer.SetActive(false);

        // Enable Rift
        riftPlayer.SetActive(true);
    }

    public void UseNormal()
    {
        // Enable Normal Camera
        normalPlayer.SetActive(true);

        // Disable Rift
        riftPlayer.SetActive(false);
    }
}
