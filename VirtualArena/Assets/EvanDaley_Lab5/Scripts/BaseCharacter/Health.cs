using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health = 100;
    public int maxHealth = 100;

    public bool debug = false;

    public void Heal(int amout)
    {
        health += amout;

        if (debug)
            print(gameObject.name + ": " + health);
    }

    public void Damage(int amount)
    {
        health -= amount;

        if(health < 1)
        {
            BroadcastMessage("Die");
        }

        if (debug)
            print(gameObject.name + ": " + health);
    }
}
