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

    public float delay = 2f;
    public GameObject spellSpawnPoint;
    public GameObject spell;
    private GameObject spellInstance;

    private Health m_Health;

    public int Health
    {
        get
        {
            if(m_Health == null)
            {
                m_Health = GetComponent<Health>();
            }

            return m_Health.health;
        }
    }

    // Use this for initialization
    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        control = GetComponent<AICharacterControl>();
        animator = GetComponent<Animator>();

        ActorList.Instance.Subscribe(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Health < 0)
        {
            // die
        }
        else if (Time.time > delay && spellInstance == null)
        {
            animator.SetBool("ThrowSpellUp", true);
            Invoke("FinishThrow", .5F);
        }
    }

    private void FinishThrow()
    {
        animator.SetBool("ThrowSpellUp", false);
    }

    public void VolleyUpStart()
    {
        print("Start");

        spellInstance = GameObject.Instantiate(spell, spellSpawnPoint.transform.position, Quaternion.identity) as GameObject;
        spellInstance.transform.SetParent(spellSpawnPoint.transform);
    }

    public void VolleyUpEnd()
    {
        print("End");

       // if (spellInstance)
       //     spellInstance = null;

        delay = Time.time + .1f;
    }

    public void Die()
    {
        //Destroy(gameObject);
    }
}