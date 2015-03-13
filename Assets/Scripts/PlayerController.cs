using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private int count;
	public GUIText countText;
	public GUIText winText;
	
	private float xPos;
	private float yPos;
	private float zPos;
	public GameObject cloneObject;
	public GameObject enemyObject;
	
	private int oneRandom;
	private int twoRandom;
	private float randPosX;
	private float randPosZ;
	
	private Vector3 bornRand;
	
	private int enemyCounter;	
	
	void Start()
	{
		enemyObject.SetActive(false);
		enemyCounter = 0;
		count = 0;
		SetCountText();
		winText.text = "";
		cloneObject.SetActive(false);
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce (movement * speed * Time.deltaTime);
		
		if(count >= 8 )
		{
			enemyObject.SetActive(true);
		}
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
			cloneObject.SetActive(true);
			MakeRandom();
			MakeClone();
			enemyCounter = enemyCounter + 1; 
			if(enemyCounter == 2 ){
				MakeRandom();
				enemyCounter = 0;
				addEnemy();
			}
		}
				
	}
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if(count>=100)
		{
			winText.text = "YOU WIN!";	
		}
	}
	
	void MakeRandom()
	{
		oneRandom = Random.Range(-8, +8);
		twoRandom = Random.Range(-8, +8);
		randPosX = (float)oneRandom;
		randPosZ = (float)twoRandom;
		bornRand.x = randPosX;
		bornRand.y = 0.5f;
		bornRand.z = randPosZ;
	}
	
	void addEnemy()
	{
		Instantiate(enemyObject, bornRand, transform.rotation);
		//cloneObject.SetActive(false);
		
	}
	
	void MakeClone()
	{
		cloneObject.GetComponent<Rotator>().enabled = false;
		
		Instantiate(cloneObject, bornRand, transform.rotation);
		cloneObject.SetActive(false);
		
	}
}
