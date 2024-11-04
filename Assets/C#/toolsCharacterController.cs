using UnityEngine;

public class toolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rigid2D;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteract_Area = .5f;


    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            useTool();
        }
    }

    private void useTool()
    {
        Vector2 position = character.lastMotionVector * offsetDistance + rigid2D.position;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteract_Area);

        foreach (Collider2D collider in colliders) { 
            Interact_hit hit = collider.GetComponent<Interact_hit>();
            if (hit != null) {
                hit.Hit();
                break;
            }
        }
    }
}
