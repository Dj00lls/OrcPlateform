using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnnemy : MonoBehaviour {
	public Transform Player;
	public Transform Fire;
	public Transform Spawn;
	private Animator anim;
	private float Speed = -500;
	private float fireRate = 2f;
	private float nextFire;
	public float walkSpeed = 1.0f;      // Walkspeed
	public float wallLeft = 0.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	float walkingDirection = 1.0f;
	Vector2 walkAmount;
	float originalX; // Original float value
	public float Distance;
	private bool LookRight = true;
	private float Direction;
	public bool Follow = false;


	private void Awake()
	{
		anim = GetComponent<Animator> ();

	}

	void Start () {
		this.originalX = this.transform.position.x;
	}

	void FixedUpdate(){
		Distance = Vector3.Distance (transform.position, Player.position);
		if(Distance <=15.0f)
		{	
			if (Time.time >= nextFire) {
				nextFire = Time.time + fireRate;
				Transform F = Instantiate(this.Fire, this.Spawn.position, Quaternion.identity);
				F.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,Speed));

			}
		}
		Destroy (GameObject.Find("Fire(Clone)"), 2);
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight) {
			walkingDirection = -1.0f;
			if (Follow == false) {
				Flip ();
			}
		} else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft) {
			walkingDirection = 1.0f;
			if (Follow == false) {
				Flip ();
			}
		}
		transform.Translate(walkAmount);
		//Distance = Vector3.Distance (transform.position, Player.position);
		if (Distance <= 25.0f) {	
			Follow = true;
			if (Direction < 0 && walkingDirection > 0) {
				Flip ();
			}
			walkingDirection = -1.0f;
			} else {
			Follow = false;
		}

		//anim.SetFloat ("Distance", Mathf.Abs(Vector3.Distance (transform.position, Player.position)));
	}

	private void Flip(){
		LookRight = !LookRight;
		Vector3 v = transform.localScale;
		v.x *= -1;
		transform.localScale = v;
	}


		
}