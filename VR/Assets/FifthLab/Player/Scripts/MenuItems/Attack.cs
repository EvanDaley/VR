/* Author: Evan Daley 
 * Date: 8/13/2015 5:27:04 AM
 * Revision: 0
 * Modified Date: 
 * Description: Attack the selected object. This script shows up in ActionItems. 
 */ 
  
using UnityEngine;
using System.Collections;
  
public class Attack : MonoBehaviour, ICreateMenuActionItem {

	public void Start()
	{
	
	}
	public void Update()
	{
	
	}

	public Canvas CreateMenuItem()
	{
		return null;
	}

	public void BeginAction()
	{
		print ("Attack!");
	}

	public void CancelAction()
	{
		print ("Stop Attacking!");
	}
}
