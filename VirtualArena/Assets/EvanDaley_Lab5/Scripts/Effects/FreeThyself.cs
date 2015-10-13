using UnityEngine;
using System.Collections;

public class FreeThyself : MonoBehaviour {

    public float minY = 2.2F;
    Transform root;
    private Rigidbody rbody;
    private bool free = false;
    public float upwardForce;
    public float scaleSpeed = 1F;

    float prevY = 0;
    bool hasReachedApex = false;
    private GameObject player;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        root = transform.root;
        rbody = GetComponent<Rigidbody>();

        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (root == null)
            return;

        if (transform.position.y > (root.position.y + minY) && free == false)
            BreakFree();

        if(free)
        {
            if(transform.position.y < prevY)
            {
                rbody.useGravity = false;
                rbody.velocity = Vector3.zero;
                hasReachedApex = true;
            }

            prevY = transform.position.y;
        }

        if(hasReachedApex)
        {
            // move toward player or something
            // expand
            float newScale = transform.localScale.x + (scaleSpeed * Time.deltaTime);
            transform.localScale = new Vector3(newScale, newScale, newScale);

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter()
    {
        if (hasReachedApex)
        {
            BroadcastMessage("Die");
        }

        
    }

    void BreakFree()
    {
        free = true; 
        transform.SetParent(null);

        rbody.AddForce(new Vector3(0, upwardForce, 0));
        rbody.useGravity = true;
    }
}
