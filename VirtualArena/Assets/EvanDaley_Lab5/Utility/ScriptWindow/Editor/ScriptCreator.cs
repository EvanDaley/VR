using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class ScriptCreator : MonoBehaviour {


	public static void CreateFromOptions(string _name,
	                                     string _description,
	                                     bool _includeHeader,
	                                     bool _includeStart,
	                                     bool _includeUpdate,
	                                     bool _includeFixed,
	                                     bool _includeOnTriggerEnter,
	                                     bool _includeOnCollisionEnter)
	{
		string path = GetPathToSelected ();

		StreamWriter sr = new StreamWriter(path + "\\" + _name + ".cs",true);

		if(_includeHeader)
			WriteHeader(sr, _description);

		WriteName(sr,_name);

		if(_includeStart)
			WriteMethod(sr, "Start");

		if(_includeUpdate)
			WriteMethod(sr, "Update");

		if(_includeFixed)
			WriteMethod(sr, "FixedUpdate");

		if(_includeOnTriggerEnter)
			WriteMethod(sr, "OnTriggerEnter");

		if(_includeOnCollisionEnter)
			WriteMethod(sr, "OnCollisionEnter");

		WriteClose(sr);

		sr.Close ();
		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh ();
	}

	public static void WriteHeader(StreamWriter sr, string _descrition)
	{
		sr.WriteLine ("/* Author: Evan Daley ");
		sr.WriteLine (" * Date: " + System.DateTime.Now.ToString ());
		sr.WriteLine (" * Revision: 0");
		sr.WriteLine (" * Modified Date: ");
		sr.WriteLine (" * Description: " + _descrition);
		sr.WriteLine (" */ ");
		sr.WriteLine ("  ");
		sr.WriteLine ("using UnityEngine;");
		sr.WriteLine ("using System.Collections;");
	}

	public static void WriteName(StreamWriter sr, string name)
	{
		sr.WriteLine ("  ");
		sr.WriteLine ("public class " + name + " : MonoBehaviour {");
		sr.WriteLine ("");
	}

	public static void WriteMethod(StreamWriter sr, string method)
	{
		sr.WriteLine ("\tpublic void " + method + "()");
		sr.WriteLine ("\t{");
		sr.WriteLine ("\t");
		sr.WriteLine ("\t}");
	}

	public static void WriteClose(StreamWriter sr)
	{
		sr.WriteLine ("}");
	}

	public static string GetPathToSelected()
	{
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
		
		return path;
	}

	public static void WriteBasic(StreamWriter sr)
	{
		//basic script methods
		
		sr.WriteLine ("\tpublic void Start()");
		sr.WriteLine ("\t{");
		sr.WriteLine ("\t");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void Update()");
		sr.WriteLine ("\t{");
		sr.WriteLine ("\t");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void FixedUpdate()");
		sr.WriteLine ("\t{");
		sr.WriteLine ("\t");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void Awake()");
		sr.WriteLine ("\t{");
		sr.WriteLine ("\t");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("}");
	}

	public static void WriteAdvanced(StreamWriter sr)
	{
		// header
		
		sr.WriteLine ("/* Author: Evan Daley ");
		sr.WriteLine (" * Date: " + System.DateTime.Now.ToString ());
		sr.WriteLine (" * Revision: 0");
		sr.WriteLine (" * Modified Date: ");
		sr.WriteLine (" * Description: ");
		sr.WriteLine (" */ ");
		
		sr.WriteLine ("using UnityEngine;");
		sr.WriteLine ("using System.Collections;");
		
		sr.WriteLine ("  ");
		sr.WriteLine ("public class GenericScript : MonoBehaviour {");
		sr.WriteLine ("");
		
		// advanced script methods
		
		sr.WriteLine ("\tpublic void Start(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void Update(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void FixedUpdate(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void LateUpdate(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void Awake(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnAnimatorIK(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnApplicationPause(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnApplicationQuit(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnBecameInvisible(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnBecameVisible(){");
		sr.WriteLine ("\t}");
		
		
		//networking
		
		sr.WriteLine ("\tpublic void OnFailedToConnect(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnConnectedToServer(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnDisconnectedFromServer(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnServerInitialized(){");
		sr.WriteLine ("\t}");
		
		
		// gui
		
		sr.WriteLine ("\tpublic void OnGUI(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnDrawGizmos(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnMouseDown(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnMouseOver(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnMouseDrag(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnMouseExit(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnMouseUpAsButton(){"); // Called when mouse is released over button that it initially pressed
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnPostRender(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnPreCull(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnRenderObject(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnValidate(){"); 	//called when inspector changed
		sr.WriteLine ("\t}");
		
		//physics
		
		sr.WriteLine ("\tpublic void OnJointBreak(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnCollisionEnter(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnCollisionEnter2D(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnCollisionExit(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnCollisionStay(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnControllerColliderHit(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnParticleCollision(){");
		sr.WriteLine ("\t}");
		
		//control
		
		sr.WriteLine ("\tpublic void OnLevelWasLoaded(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnEnable(){");
		sr.WriteLine ("\t}");
		
		
		sr.WriteLine ("\tpublic void OnDestroy(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnDisable(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnTransformChildrenChanged(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("\tpublic void OnTransformParentChanged(){");
		sr.WriteLine ("\t}");
		
		sr.WriteLine ("}");
	}
}
