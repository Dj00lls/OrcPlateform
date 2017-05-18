using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public LayerMask playerLayer;
    public Rigidbody2D rigidbody2D;
    private float jump = 350f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void HitSpawner()
    {
        Debug.Log("test hit");
        if (Physics2D.OverlapCircle(this.transform.position, 1f, playerLayer))
        {
            rigidbody2D.AddForce(new Vector2(0, jump));
        }
    }
}
