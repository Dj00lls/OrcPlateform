using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlateform : MonoBehaviour {
    public LayerMask playerLayer;
    public float fallDelay = 0.2f;
    Rigidbody2D gameObjectsRigidBody;
    // Use this for initialization
    void Start () {
		gameObjectsRigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        gameObjectsRigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(this.transform.position, 1f, playerLayer))
        {
            Invoke("Fall", fallDelay);
        }
    }
    void Fall()
    {
        gameObjectsRigidBody.isKinematic = false;
    }
}
