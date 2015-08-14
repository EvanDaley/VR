/* Author: Evan Daley 
 * Date: 8/13/2015 5:18:32 AM
 * Revision: 0
 * Modified Date: 
 * Description: Gets a list of components that can add items to the Action List. Creates 3D menus when user selects objects. 
 */ 
  
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMenu : MonoBehaviour {

	public List <ICreateMenuActionItem> Behaviors;

	public void Start()
	{
		Behaviors = new List<ICreateMenuActionItem>();
		GetComponentList ();
		PrintBehaviors ();

		DrawMenus ();
	}

	// Get a list of all the components that can add options to the menu
	public void GetComponentList()
	{
		Behaviors.Clear();
		ICreateMenuActionItem [] results = GetComponentsInChildren<ICreateMenuActionItem>();

		foreach(ICreateMenuActionItem item in results)
		{
			Behaviors.Add (item);
		}
	}

	public void PrintBehaviors()
	{
		foreach(object o in Behaviors)
		{
			print ("Object: " + o);
		}
	}

	public void SelectObject(GameObject select)
	{

	}

	public void DrawMenus()
	{
		// CreateMenuItem() on each ICreateMenuItem
		// ignore null results
		foreach(ICreateMenuActionItem behavior in Behaviors)
		{
			behavior.CreateMenuItem ();
		}
	}


}
