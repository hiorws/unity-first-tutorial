using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public GUIText gameOver;
	public GameObject player;
	public GameObject c1;
	public GameObject c2;
	public GameObject c3;
	public GameObject c4;
	
	void start()
	{
		gameOver.text= "";
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			gameOver.text = "GAME OVER!";
			player.SetActive(false);
			c1.renderer.material.color = Color.red;
			c2.renderer.material.color = Color.red;
			c3.renderer.material.color = Color.red;
			c4.renderer.material.color = Color.red;
		}
	}
}
