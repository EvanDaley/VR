using UnityEngine;
using System.Collections;

public class SimpleBotController : MonoBehaviour {

	private SimpleBotMotor motor;

	void Awake () {
		motor = GetComponent<SimpleBotMotor> ();
		motor.Target = new Vector3 (100, 0, 0);
	}

	void Update () {
	
	}
}
