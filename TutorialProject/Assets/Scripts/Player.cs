using UnityEngine;
using UnityEngine.InputSystem; // <-- Add this

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;
    private float movementX;

    [SerializeField] private Rigidbody2D myBody;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";

    private SpriteRenderer sr;

    private bool isGrounded;



    private void Start()
    {
        //start
    }
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            //moving right
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            //moving left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            //not moving
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }


















}//end of class