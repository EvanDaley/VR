using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager Instance;
	private int clickCount = 0;

	// Use this for initialization
	void Start () {
		print ("Didn't load save.");
		Instance = this;
	}

	public int ClickCount
	{
		set
		{
			clickCount = value;
			// create event

			print (clickCount);
		}
		get{return clickCount;}
	}
}


