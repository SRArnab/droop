using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
	Rigidbody rb;
	public float speed = 5;
	//public float jumpHeight;
	public GameObject[] Lives;
	int lifeId = -1;
	private Vector3 startPOs;
	private int count;
	public Text countText;
	public GameObject menuContainer;
	//public Transform GroundCheckPoint;
	//public float GroundCheckRadius;
	public LayerMask GroundLayer;
	private bool isTouchingGround;
	private bool onGround;
	public bool belowGrounded;
	Vector3 playerStartPos;
	private const int MAX_jump = 2;
	private int currentJump = 0;

	private void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.tag == "step")
		{
			isTouchingGround = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		/*if (collision.gameObject.tag == "step")
		{
			isTouchingGround = true;
		}*/
		onGround = true;
		currentJump = 0;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("cylinder"))
		{
			//Destroy(other.gameObject);
			count = count + 1;
			SetCountText();

		}
	}
	void SetCountText()
	{
		countText.text = "Score: " + count.ToString();
	}
	public void DecreaseLife(int _lifeID)
	{
		if(_lifeID<Lives.Length-1)
		{
			Lives[_lifeID].gameObject.SetActive(false);
			PlayerReset();
		}
		else
		{
			Lives[_lifeID].gameObject.SetActive(false);
			menuContainer.SetActive(true);
			GameOver();

		}
		
	}

	public void PlayerReset()
	{
		transform.position = playerStartPos;
		//belowGrounded = false;
	}
	void Start()
    {
		rb = GetComponent<Rigidbody>();
		//playerStartPos = transform.position;

		Vector3 moveMent = new Vector3(0f, 0f, speed);
		rb.AddForce(moveMent);
    }

	/*public void Jump()
	{

		Vector3 jumpVector = new Vector3(0, jumpHeight, 0f);
		rb.AddForce(jumpVector);

	}*/
	void Update()
    {
		/*if (Input.GetKey(KeyCode.Space))
		{
			Debug.Log("space down");
			if (isTouchingGround)
			{
				Jump();
			}
			else
			{

			}*/
			if(Input.GetKeyDown("space") && (onGround|| MAX_jump>currentJump))
			{
				rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
				onGround = false;
			}
			

		if (transform.position.y < -0.5 && !belowGrounded)
		{
			belowGrounded = true;
			lifeId++;
			DecreaseLife(this.lifeId);
			
		}
	    

	}
	public void GameOver()
	{
		Debug.Log("Game over");
	}
	private void FixedUpdate()
	{
	}
}
