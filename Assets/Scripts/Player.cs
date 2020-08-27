using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;

    private Rigidbody2D rb;
    private float xDisplacement;
    private bool isGrounded;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            isGrounded = false;
        }
        animator.SetFloat("runSpeed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("jumpSpeed", Mathf.Abs(rb.velocity.y));
        if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        else if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
        animator.SetTrigger("grounded");
        isGrounded = true;
        if (col.gameObject.name.Equals("Elevator"))
            this.transform.parent = col.transform;
    }
  

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Elevator"))
            this.transform.parent = null;
    }
}
