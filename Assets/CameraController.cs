using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		Debug.Log("here!!");
		var currentPlayer = GameObject.Find("Hero");
		Debug.Log("currentPlayerForCamera " + currentPlayer);
	}
	
	// Update is called once per frame
	void Update () {

		// transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
	}
}
