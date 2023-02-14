using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] LayerMask LayerGround;
    [SerializeField] Transform checkGround;
    [SerializeField] string isGroundedBool = "Chao";
    [SerializeField] float jumpForce = 650f;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private GameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        _gameController = FindObjectOfType(typeof(GameController)) as GameController;

        MovimentaPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        
    }

    void MovimentaPlayer()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));

        if(Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, LayerGround))
        {
            animator.SetBool(isGroundedBool, true);
            isGrounded = true;
        }
        else
        {
            animator.SetBool(isGroundedBool, false);
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if(isGrounded) //true
        {
            _gameController.fxGame.PlayOneShot(_gameController.fxJump);
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
