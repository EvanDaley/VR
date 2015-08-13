/* Author: Evan Daley 
 * Date: 8/13/2015 5:04:59 AM
 * Revision: 0
 * Modified Date: 
 * Description: An interface to be implemented by any component that can add options to the menu. 
 */ 
  
using UnityEngine;
using System.Collections;
  
public interface ICreateMenuActionItem 
{
	//Canvas CreateMenuItem();
	void CompleteAction();
	//void CancelAction();
}
