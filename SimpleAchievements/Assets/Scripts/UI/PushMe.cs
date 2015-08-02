using UnityEngine;
using System.Collections;

public class PushMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Button_Pushed()
	{
		ScoreManager.Instance.ClickCount ++;
	}
}