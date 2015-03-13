using UnityEngine;
using System.Collections;

public class CornerRotator : MonoBehaviour {
	
	public float speed;
	
	void Update()
	{
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime *  speed);
	}



}
