using System;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    CharacterController2D characterController;
    Rigidbody2D rigid2D;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteract_Area = 1.5f;
    Character character;
    [SerializeReference] HighlightController highlightController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        rigid2D = GetComponent<Rigidbody2D>();
        character=GetComponent<Character>();
    }
    private void Update()
    {
        Check();
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Check()
    {
        Vector2 position = characterController.lastMotionVector * offsetDistance + rigid2D.position;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteract_Area);

        foreach (Collider2D collider in colliders)
        {
            Interactable hit = collider.GetComponent<Interactable>();
            if (hit != null)
            {
                highlightController.Highlight(hit.gameObject);
                return;
            }
        }
        highlightController.Hide();
    }

    private void Interact()
    {
        Vector2 position = characterController.lastMotionVector * offsetDistance + rigid2D.position;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteract_Area);

        foreach (Collider2D collider in colliders)
        {
            Interactable hit = collider.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
