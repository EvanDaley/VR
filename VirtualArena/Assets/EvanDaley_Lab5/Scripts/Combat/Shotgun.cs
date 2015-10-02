/* Author: Evan Daley 
 * Date: 10/2/2015 7:53:43 AM
 * Revision: 0
 * Modified Date: 
 * Description: A simple shotgun class for the player to hold. Recieves a broadcast from the player to fire. 
 * When the weapon is active and a child of player, the WeaponManager will control the weapon thru broadcasts.
 */ 
  
using UnityEngine;
using System.Collections;
  
public class Shotgun : MonoBehaviour {

    public Transform barrelEnd;

    public float initialRadius = .3F;
    public int numberOfPellets = 12;
    public int blastForce = 10;
    public float outwardForce = 1;

    public GameObject standardAmmo;

    /// <summary>
    /// Blasts projectiles directly forward.
    /// </summary>
    public void Fire()
    {
        for (int i = 0; i < numberOfPellets; i++)
        {
            // Get a random point in a sphere for calculating offsets
            Vector3 pointInSphere = Random.insideUnitSphere * initialRadius;

            // The end of the barrel plus an offset
            Vector3 spawnPosition = barrelEnd.transform.position + pointInSphere;

            // launch with a slightly randomized direction
            GameObject shot = GameObject.Instantiate(standardAmmo, spawnPosition, transform.rotation) as GameObject;
            Rigidbody rbody = shot.GetComponent<Rigidbody>();

            // slightly randomize direction
            Vector3 blastDirection = transform.forward * blastForce;
            Vector3 randomizedForce = Vector3.ProjectOnPlane(pointInSphere, transform.forward);

            // Vector3 localDirection = blastDirection.
            Vector3 totalForce = blastDirection + (randomizedForce * outwardForce);

            // add force as impulse
            rbody.AddForce(totalForce, ForceMode.Impulse);
        }
    }

    void DropWeapon()
    {
        transform.SetParent(null);
    }
}
