using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health = 100;

    public void Damage(int amount)
    {
        health -= amount;

        if(health < 1)
        {
            BroadcastMessage("Die");
        }
    }
}
