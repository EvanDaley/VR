using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class TextFileCreator : MonoBehaviour {


	
	[MenuItem("Assets/Create/Text File")]
	public static void Init()
	{
		//var file = Selection.activeObject.name;
		//DoSomethingToFile( file );
		//print ("Creating text file");
		string path = "";
		var obj = Selection.activeObject;
		if (obj == null) path = "Assets";
		else path = AssetDatabase.GetAssetPath(obj.GetInstanceID());
		
		if (path.Length > 0)
		{
			if (Directory.Exists(path))
			{
				//Debug.Log("Selected Object Type: Folder");
			}
			else
			{
				//Debug.Log("Selected Object Type: File");
				path = Path.GetDirectoryName (path);
			}
		}
		else
		{
			Debug.Log("Not in assets folder");
		}
		
		//System.IO.File.WriteAllText(path, "");
		StreamWriter sr = File.CreateText (path + "\\New Text File.txt");
		sr.WriteLine (" Author: Evan Daley ");
		sr.WriteLine (" Date: " + System.DateTime.Now.ToString ());
		AssetDatabase.Refresh();
		sr.Close ();

	}
}

