using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DommageBox : MonoBehaviour {
    // Use this for initialization
    public LayerMask playerLayer;
    public LayerMask groundLayer;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.OverlapCircle(this.transform.position, 0.4f, playerLayer))
            Destroy(this.gameObject);
    }
}
