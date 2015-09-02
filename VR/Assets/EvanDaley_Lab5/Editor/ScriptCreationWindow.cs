using UnityEngine;
using System.Collections;
using UnityEditor;

public class ScriptCreationWindow : EditorWindow {

	string _name = "NewScript";
	string _description = "";
	bool _includeHeader = true;

	bool _includeStart = true;
	bool _includeUpdate = true;
	bool _includeFixed = false;
	bool _includeOnTriggerEnter = false;
	bool _includeOnCollisionEnter = false;

	[MenuItem("Assets/Open Script Window")]
	static void Init()
	{
		// Get existing open window or if none, make a new one:
		ScriptCreationWindow window = (ScriptCreationWindow)EditorWindow.GetWindow (typeof (ScriptCreationWindow));
		window.Show();
	}

	void OnGUI()
	{
		EditorStyles.textField.wordWrap = true;
		GUILayout.Label("Create a New Script", EditorStyles.boldLabel);
		_name = EditorGUILayout.TextField ("Script Name", _name);

		_description = EditorGUILayout.TextField ("Description", _description, GUILayout.Height(60));

		_includeHeader = EditorGUILayout.Toggle ("Include Header",_includeHeader);

		EditorGUILayout.Space ();

		_includeStart = EditorGUILayout.Toggle ("Include Start",_includeStart);
		_includeUpdate =EditorGUILayout.Toggle ("Include Update",_includeUpdate);

		//EditorGUILayout.Space ();

		_includeFixed = EditorGUILayout.Toggle ("Include FixedUpdate",_includeFixed);
		_includeOnTriggerEnter = EditorGUILayout.Toggle ("Include TriggerEnter",_includeOnTriggerEnter);
		_includeOnCollisionEnter = EditorGUILayout.Toggle ("Include CollisionEnter",_includeOnCollisionEnter);

		if(GUILayout.Button ("Create Script"))
		{
			ScriptCreator.CreateFromOptions (_name, _description, _includeHeader, _includeStart, _includeUpdate, _includeFixed, _includeOnTriggerEnter, _includeOnCollisionEnter);
			this.Close ();
		}
	}
}
