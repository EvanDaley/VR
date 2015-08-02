using UnityEngine;
using System.Collections;

public static class PhysicsTools 
{
 	public static Vector3 GetRayHitpoint(Ray ray)
	{
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, 20))
		{
			return hit.point;
		}

		return Vector3.zero;
	}

	public static Vector3 GetRayHitpoint(Ray ray, float distance)
	{
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, distance))
		{
			return hit.point;
		}
		
		return Vector3.zero;
	}
}
