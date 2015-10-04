using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class CustomEnemy : MonoBehaviour
{

    private NavMeshAgent agent { get; set; } // the navmesh agent required for the path finding
    private ThirdPersonCharacter character { get; set; } // the character we are controlling
    public Transform target; // target to aim for
    private AICharacterControl control;
    private Animator animator;

    public int health = 100;
    public float delay = 2f;

    // Use this for initialization
    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        control = GetComponent<AICharacterControl>();
        animator = GetComponent<Animator>();

    }


    // Update is called once per frame
    private void Update()
    {
        if(health < 0)
        {
            // die
        }

        if (Time.time > delay)
        {
            Invoke("FinishThrow", 0.8F);
            animator.SetBool("ThrowSpellUp", true);
            delay = Time.time + 1F;
        }
    }

    private void FinishThrow()
    {
        animator.SetBool("ThrowSpellUp", false);
    }

}