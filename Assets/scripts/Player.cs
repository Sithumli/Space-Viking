using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private SpriteRenderer sr;
    private float movementx;
    private Rigidbody2D mybody;
    private Animator anim;
    private string walkAnim = "walk";
    private bool isGrounded = true;
    private string Ground = "ground";
    private string floor = "floor";
    private string r = "rock";
    private string p = "portal";
    private bool hasHitRock = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    void Update()
    {
        palyermovekeyboard();
        playeramine();
        pjump();
    }

    private void FixedUpdate()
    {
        pjump();
    }

    void palyermovekeyboard()
    {
        movementx = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementx, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void playeramine()
    {
        if (movementx > 0)
        {
            anim.SetBool(walkAnim, true);
            sr.flipX = false;
        }
        else if (movementx < 0)
        {
            anim.SetBool(walkAnim, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(walkAnim, false);
        }
    }

    void pjump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(floor))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
        if (collision.gameObject.CompareTag(r) && !hasHitRock)
        {
            hasHitRock = true;
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
        if (collision.gameObject.CompareTag(p))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("menu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(floor))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
        if (collision.gameObject.CompareTag(p))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("menu");
        }
    }
}
