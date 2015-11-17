using UnityEngine;
using System.Collections;

public interface ITargeting
{

	Vector3 TargetPoint
	{
		get;
	}
	
	Transform Target
	{
		get;
	}

	void UpdateTargeting();
}
