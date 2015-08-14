/* Author: Evan Daley 
 * Date: 8/13/2015 5:12:09 AM
 * Revision: 0
 * Modified Date: 
 * Description: Move to the point in space that the camera is centered on. Included in ActionItems in Player.
 */ 
  
using UnityEngine;
using System.Collections;
  
public class MoveToSelected : MonoBehaviour, ICreateMenuActionItem {

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
		print ("Walk to point.");
	}

	public void CancelAction()
	{
		print ("Stop Moving!");
	}
}
