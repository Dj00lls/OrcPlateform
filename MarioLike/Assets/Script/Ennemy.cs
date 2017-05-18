using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour {
	
	//initialization 
	void Start () { } 

	// Update 
	void Update () { 

	} 
	void OnCollisionEnter(Collision col) { 
		if (col.gameObject.tag == "PlayerDegat" )
		{ 
			Destroy(col.gameObject); 
		} 
	} 
}
