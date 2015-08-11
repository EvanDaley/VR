using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour {

	protected Canvas _Canvas;

	void Start()
	{
		_Canvas = GetComponentInParent<Canvas>();
	}
}
