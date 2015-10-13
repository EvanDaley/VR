using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class DamageInRange : MonoBehaviour
    {
        public int damage;
        public float range;


        private IEnumerator Start()
        {
            // wait one frame because some explosions instantiate debris which should then
            // be pushed by physics force
            yield return null;

            //float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;

            float r = range;
            var cols = Physics.OverlapSphere(transform.position, r);
            var healths = new List<Health>();
            foreach (var col in cols)
            {
                Health health = col.GetComponent<Health>();
                if (health != null && !healths.Contains(health))
                {
                    healths.Add(health);
                }
            }
            foreach (var health in healths)
            {
                health.Damage(damage);
            }
        }
    }
}
