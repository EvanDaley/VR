using UnityEngine;
using System.Collections;

public class DamageOnImpact : MonoBehaviour {

    public int damage = 1;

	void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Character")
        {
            other.gameObject.GetComponent<Health>().Damage(damage);
        }
    }
}
