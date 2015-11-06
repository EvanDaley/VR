using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;

public class PlayerSpawner : MonoBehaviour {

	public bool autoConnect = true;
	public string playerPrefab;
	public GameObject cameraPrefab;

	private PhotonView m_PhotonView;

	void Start () {
		m_PhotonView = GetComponent<PhotonView>();

		if(autoConnect)
		{
			PhotonNetwork.ConnectUsingSettings("0.1");
		}
	}

	void OnFailedToConnectToPhoton()
	{
		PhotonNetwork.offlineMode = true;
	}

	void OnDisconnectedFromPhoton()
	{
		// disconnected
	}

	void OnConnectedToMaster()
	{
		JoinOrCreateRoom();
	}

	public void JoinOrCreateRoom()
	{
		PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions(){}, TypedLobby.Default);
	}

	public void OnJoinedRoom()
	{
		SpawnNewPlayer ();
	}


	// TODO: PASS IN A LOCATION OR FIND ONE
	void SpawnNewPlayer()
	{
		// get the main local camera so we can deactivate it
		GameObject cam = Camera.main.gameObject;

		// create the player
		GameObject player = PhotonNetwork.Instantiate(playerPrefab,transform.position,transform.rotation,0);

		// create the camera and make it target the new player
		GameObject newCam = GameObject.Instantiate (cameraPrefab,transform.position,transform.rotation) as GameObject;
		FreeLookCam m_cam = newCam.GetComponent<FreeLookCam>();
		m_cam.SetTarget(player.transform);

		// deactivate original camera
		cam.SetActive (false);
	}

	void RespawnPlayer()
	{
		// reset and resuse player
	}

	void Update () {
		
	}
}
