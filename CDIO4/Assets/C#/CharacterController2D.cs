using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    Vector2 vector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        vector = new Vector2(horizontal,vertical);
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);
        
        if (moving) {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;

            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    void FixedUpdate() {
        Move();
    }

    private void Move()
    {
        rigidbody2d.linearVelocity = vector * speed;
    }
}
