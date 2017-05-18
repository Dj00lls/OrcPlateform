using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnnemy : MonoBehaviour {

	public Transform Player;
	private float Distance;
	public Transform Fire;
	public Transform Spawn;
	private float Speed = -500;
	private float fireRate = 4f;
	private float nextFire;
	void Start () {
		nextFire = 0;
	}

	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance (transform.position, Player.position);
		if(Distance <=10.0f)
		{	
			if (Time.time >= nextFire) {
				nextFire = Time.time + fireRate;
				Transform F = Instantiate(this.Fire, this.Spawn.position, Quaternion.identity);
				F.GetComponent<Rigidbody2D> ().AddForce (new Vector2(Speed,0));


			}

		}
		Destroy (GameObject.Find("Fire(Clone)"), 2);

	}
}
