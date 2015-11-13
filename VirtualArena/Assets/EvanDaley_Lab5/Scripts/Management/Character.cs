/* Author: Evan Daley 
 * Date: 11/8/2015 12:22:03 PM
 * Revision: 0
 * Modified Date: 
 * Description: A serializable player character. This class contains all of the long-term player data and a few helper functions.
 * When the class is serialized it should be encrypted, written to a binary format, and saved in Application.data path. Players can
 * copy their characters and make backups but editing the save file should be impossible. Mimimum security should include a checksum on load.
 */ 
  
using UnityEngine;
using System.Collections;
  

[System.Serializable]
public class Character {

	public string name = "Harth Garblegarm";

	public Character(string name)
	{

	}
}
