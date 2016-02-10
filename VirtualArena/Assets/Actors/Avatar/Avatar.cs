using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour, IKillable, IDamageable<float>
{
	public string displayName = "Jonathan";

	// The health of this unit. Use some sort of complicated algorithm for generating health on spawn.
	private float health = 100;	// TODO: Set based on monster's level.

	//The required method of the IDamageable interface. This should use extremely complex algorithms 
	// to account for shields, armor, vulnerabilities, area of hit, etc.
	public void Damage(float damageTaken)
	{
		health -= damageTaken;

		if (health < 0)
		{
			health = 0;
			Kill ();
		}
	}

	//The required method of the IKillable interface
	public void Kill()
	{
		print ("Destroyed!");
		GameObject.Destroy (gameObject);
	}
}