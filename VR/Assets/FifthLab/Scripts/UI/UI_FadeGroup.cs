/* UI_FadeGroup
 * Author: Evan Daley
 * Description: Place on a Canvas Group. When the user is looking away the group will fade out
 */

using UnityEngine;
using System.Collections;

public class UI_FadeGroup : UI_Base {

	private bool mouseOver = false;
	private CanvasGroup _group;

	// Use this for initialization
	void Start () {
		_group = GetComponent<CanvasGroup>();
		_group.alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(mouseOver)
			FadeIn ();
		else
			FadeOut ();
	}

	public void MouseEnter()
	{
		print ("fading in");
		mouseOver = true;
	}

	public void MouseExit()
	{
		print ("fading out");
		mouseOver = false;
	}

	private void FadeIn()
	{
		if(_group.alpha == 1)
			return;

		if(_group.alpha < .99f)
		{
			_group.alpha += .01f;

		}
		else
		{
			_group.alpha = 1;
		}
	}

	private void FadeOut()
	{
		if(_group.alpha == 0)
			return;
		
		if(_group.alpha > .01f)
		{
			_group.alpha -= .05f;

		}
		else
		{
			_group.alpha = 0;
		}
	}
}
