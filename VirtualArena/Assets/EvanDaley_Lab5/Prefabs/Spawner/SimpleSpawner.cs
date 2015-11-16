using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour {

	public string enemy = "EvilCube";
	public float interval = 25;
	private float cooldown = float.MaxValue;
	private Transform m_Transform;

	void Start()
	{
		m_Transform = GetComponent<Transform> ();
	}

	void Update () {
		cooldown -= Time.deltaTime;
		if (cooldown < 0) {
			SpawnEnemy();
			cooldown = interval;
		}
	}

	void OnCreatedRoom()
	{
		cooldown = 0;
	}

	void SpawnEnemy()
	{
		PhotonNetwork.Instantiate (enemy, m_Transform.position + Vector3.up*2, m_Transform.rotation, 0);
	}
}
