using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    Vector2 vector;
    Animator animator;
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
        vector = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
    }

    void FixedUpdate() {
        Move();
    }

    private void Move()
    {
        rigidbody2d.linearVelocity = vector * speed;
    }
}
