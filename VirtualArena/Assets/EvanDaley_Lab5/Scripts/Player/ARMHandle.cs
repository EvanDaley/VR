using UnityEngine;
using System.Collections;

public class ARMHandle : MonoBehaviour {

    public static ARMHandle Instance;

    void Start()
    {
        Instance = this;
    }
}
