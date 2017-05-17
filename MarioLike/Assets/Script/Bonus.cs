using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {
    public LayerMask playerLayer;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.OverlapCircle(this.transform.position, 0.5f, playerLayer))
        {
            Debug.Log("lol");
            //this.transform.gameObject.
            Destroy(this.gameObject);
            
        }   
    }
    
}
