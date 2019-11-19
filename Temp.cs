using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
	Rigidbody rb;
	public float speed = 10;
	public float jumpHeight;
	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();

	
		Vector3 moveMent = new Vector3(0f, 0f, speed);
		rb.AddForce(moveMent);
	}

	public void Jump()
	{
		 
		Vector3 jumpVector = new Vector3(0, jumpHeight, 0f);
		rb.AddForce(jumpVector);
	}

	// Update is called once per frame
	void Update()
    {
		

		if (Input.GetKey(KeyCode.Space))
		{
			Debug.Log("space down");
			Jump();
		}
    }
}
