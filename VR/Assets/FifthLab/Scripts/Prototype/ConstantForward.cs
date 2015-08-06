using UnityEngine;
using System.Collections;

public class ConstantForward : MonoBehaviour {

	Transform _transform;
	public float distance = 1f;

	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		_transform.position = _transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
	}
}
