using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnnemy : MonoBehaviour {
	public Transform Player;
	private Animator anim;
	public float walkSpeed = 1.0f;      // Walkspeed
	public float wallLeft = 0.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	float walkingDirection = 1.0f;
	Vector2 walkAmount;
	float originalX; // Original float value
	private float Distance;
	public bool LookRight = true;
	public bool IsAttack = false;
	public bool Follow = false;
	public Collider2D Attack;
	private float AttackSpeed = 1.0f;
	private float nextFire;
	private float Direction;

	private void Awake()
	{
		anim = GetComponent<Animator> ();
		Attack.enabled = false;

	}
	void Start () {
		this.originalX = this.transform.position.x;
	}

	void FixedUpdate(){
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
		transform.Translate (walkAmount);
		Distance = Vector3.Distance (transform.position, Player.position);
		anim.SetFloat ("Distance", Mathf.Abs (Distance));
		Direction = Player.position.x - transform.position.x;
		if (Distance <= 12.0f) {
			Follow = true;	
			if (Direction < 0 && walkingDirection > 0) {
				Flip ();
			}
			walkingDirection = -1.0f;
			if (Distance <= 5.0f) {	
				IsAttack = true;
				if (AttackSpeed > 0) {
					if (IsAttack) {
						AttackSpeed -= Time.deltaTime;
						Attack.enabled = true;
						if (AttackSpeed <= 1.7f) {
							Attack.enabled = false;
						}
					}
				}else{
					IsAttack = false;
					Attack.enabled = false;
				} 
			} else {
				Follow = false;
			}

		}AttackSpeed = 2.0f;
	}
		

	private void Flip(){
		LookRight = !LookRight;
		Vector3 v = transform.localScale;
		v.x *= -1;
		transform.localScale = v;
	}
		
}
