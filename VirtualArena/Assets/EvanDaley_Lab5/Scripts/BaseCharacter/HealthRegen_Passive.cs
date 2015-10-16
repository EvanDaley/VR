/* HealthRegen_Passive
 * Author: Evan Daley
 * Date: 10/14/15
 * Description: The basic premise is that we want to add a chunk of health after a set time-span. The time-span is 
 * determined by Time.deltaTime * healRate. After each chunk of time we add healAmount of health. */

using UnityEngine;
using System.Collections;

public class HealthRegen_Passive : MonoBehaviour {

    // Reference objects health
    public Health m_Health;

    // The amount we heal after pointGrowth reaches 1
    public int healAmount = 10;

    // Healing is in ints but pointGrowth gives more fine grained control.
    public float pointGrowth = 0;

    // Time.deltaTime * healMultiplier determines pointGrowth. pointGrowth * healAmount determines regeneration.
    public float healRate = 1;

	void Start () {
        GetHealth();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Health == null)
            GetHealth();

        if (m_Health.health < 0)
            return;

        if(m_Health.health < m_Health.maxHealth)
        {
            // begin healing immediately
            pointGrowth += Time.deltaTime * healRate;

            if(pointGrowth > 1)
            {
                // reset the counter
                pointGrowth -= 1;

                // add health
                m_Health.Heal(healAmount);
            }
        }
        
	}

    void GetHealth()
    {
        m_Health = GetComponent<Health>();
    }
}
