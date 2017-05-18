using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveOrc : MonoBehaviour {
    private Animator anim;
    public float speed = 1.5f;
    public Rigidbody2D rigidbody2D;
    private bool facingLeft = true;
    private float jump = 350f;
    public LayerMask groundLayer;
    public LayerMask gameOverLayer;
    public LayerMask spawnerLayer;
    public LayerMask pickLayer;
    private spawner other;
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        //rigidbody2D.velocity = new Vector3(move * speed, rigidbody2D.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(move));
        if (move < 0 && facingLeft)
        {
            Flip();
        }
        else if (move > 0 && !facingLeft)
        {
            Flip();
        }
        this.transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("special");
            if (Physics2D.OverlapCircle(this.transform.position, 1f, spawnerLayer))
            {
                other.HitSpawner();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && Physics2D.OverlapCircle(this.transform.position, 0.5f, groundLayer))
            rigidbody2D.AddForce(new Vector2(0, jump));
        if (Physics2D.OverlapCircle(this.transform.position, 0.5f, gameOverLayer))
            Application.LoadLevel(Application.loadedLevel);
        if(Physics2D.OverlapCircle(this.transform.position, 0.5f, groundLayer))
            this.transform.position += Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * speed;
        if (Physics2D.OverlapCircle(this.transform.position, 0.5f, pickLayer))
        {
            Debug.Log("Test");
            //rigidbody2D.AddForce(new Vector2(0, 100f));

            this.transform.GetComponent<Collider2D>().isTrigger= true;
        }
    }
    public void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
