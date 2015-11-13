/* MainMenu.cs
 * Author: Evan Daley
 * Revision: 0
 * Rev. Author: 
 * Description: An interactive menu to start the game.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	
	// Called when the user presses "PLAY SINGLE PLAYER". Loads the first scene.
	public void ButtonPressed_StartGame()
	{
		print ("Starting new game");
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void ButtonPressed_Quit()
	{
		print ("Quitting from main menu");
		Application.Quit();
	}

	// User selected "Modify Database". Load the DB editor scene.
	public void ButtonPressed_MDB()
	{
		print ("Modify database");
		Application.LoadLevel ("ModifyDB");
	}

	public void ButtonPressed_ResetButton()
	{
		GameObject buttonObject = GameObject.Find ("Button_Confirm");
		Text button = buttonObject.GetComponentInChildren<Text>();
		
		button.text = "CONFIRM NAME";
		
	}

	public void ButtonPressed_LoadCharacter()
	{
		// Get users text
		GameObject inputObject = GameObject.Find("InputField");
		InputField inputField = inputObject.GetComponent<InputField>();
		string name = inputField.text;
		print ("Name: " + name);

		// Find save
		Character player = SaveLoad.FindCharacter(name);

		// If save found, load right away
		if(player != null)
		{
			print ("Found character! Loading");

			GameStateManager.Instance.player = player;

			Application.LoadLevel (Application.loadedLevel + 1);

			return;
		}

		// If no save found, prompt to create new 
		GameObject buttonObject = GameObject.Find ("Button_Confirm");
		Text button = buttonObject.GetComponentInChildren<Text>();

		if(button.text == "NEW CHARACTER?")
		{
			// Create new
			print ("Creating new character");
		}

		button.text = "NEW CHARACTER?";
	}

	public void ButtonPressed_Options()
	{
		print ("ButtonPressed Options");
	}

	public void ButtonPressed_Extras()
	{
		print ("ButtonPressed Extras");
	}
}
