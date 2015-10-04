using UnityEngine;
using System.Collections;

public class FreeThyself : MonoBehaviour {

    public float minY = 2.2F;
    Transform root;
    private Rigidbody rbody;
    private bool free = false;

	// Use this for initialization
	void Start () {
        root = transform.root;
        rbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > (root.position.y + minY) && free == false)
            BreakFree();
	}

    void BreakFree()
    {
        free = true; 
        transform.SetParent(null);
        rbody.AddForce(new Vector3(0, 45, 0));
        rbody.useGravity = true;
    }
}
