using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad 
{
	/// <summary>
	/// Find the user specificed Character in the list of saves.
	/// </summary>
	/// <returns>The character.</returns>
	/// <param name="name">Name.</param>
	public static Character FindCharacter(string name)
	{
		Character player = null;

		string fileName = name + ".lab5";

		FileInfo[] files = GetAllFiles ();

		foreach(FileInfo file in files)
		{
			Debug.LogFormat ("Found file: " + file.Name);
			
			if(file.Name == fileName)
			{
				Debug.Log("Found 1");

				// player = save file
			}
		}

		return player;
	}

	/// <summary>
	/// Returns an array of files found in Application.persistentDataPath
	/// </summary>
	/// <returns>The all files.</returns>
	public static FileInfo[] GetAllFiles()
	{
		//TODO: Expose this path to the user so they can find their save files.
		string path = Application.persistentDataPath;
		//Debug.Log(path);
		
		DirectoryInfo info = new DirectoryInfo(path);
		FileInfo[] files = info.GetFiles();
		
		return files;
	}

	/// <summary>
	/// Saves the character and returns true if no errors occured.
	/// </summary>
	/// <returns><c>true</c>, if character was saved, <c>false</c> otherwise.</returns>
	public static bool SaveCharacter()
	{
		// take the current character and save it into a binary format


		return true;
	}
}
