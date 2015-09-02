/* Author: Evan Daley 
 * Date: 8/10/2015 5:24:48 PM
 * Revision: 0
 * Modified Date: 
 * Description: Load any scene after a certain amount of time has passed. Scene is referenced using index in build settings.
 */ 
  
using UnityEngine;
using System.Collections;
  
public class LoadLevelAfterTime : MonoBehaviour 
{
	public float delay = 1.5f;
	private float timeUntilLoad = 100000f;

	void Start()
	{
		timeUntilLoad = Time.time + delay;
	}

	void Update()
	{
		if(Time.time > timeUntilLoad)
			Application.LoadLevel (Application.loadedLevel + 1);
	}
}
