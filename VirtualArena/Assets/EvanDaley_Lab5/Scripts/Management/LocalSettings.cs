using UnityEngine;
using System.Collections;

public class LocalSettings : MonoBehaviour {

    [HideInInspector]
    public static LocalSettings instance;

    public bool autoDetectRift = true;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
