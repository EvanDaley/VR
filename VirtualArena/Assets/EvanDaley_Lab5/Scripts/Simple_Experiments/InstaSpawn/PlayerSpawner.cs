using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public bool autoConnect = true;
	public string playerPrefab;
	public string cameraPrefab;

	private PhotonView m_PhotonView;

	void Start () {
		m_PhotonView = GetComponent<PhotonView>();

		if(autoConnect)
		{
			PhotonNetwork.ConnectUsingSettings("0.1");
		}
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
		print ("Room: " +  PhotonNetwork.room);
		PhotonNetwork.Instantiate(playerPrefab,transform.position,transform.rotation,0);
		PhotonNetwork.Instantiate(cameraPrefab,transform.position,transform.rotation,0);
	}

	void Update () {
		
	}
}
