using Unity.VisualScripting;
using UnityEngine;

public class LootContainterInteract : Interactable
{
    [SerializeField] GameObject openedChest;
    [SerializeField] GameObject closedChest;
    [SerializeField] bool opened;

    public override void Interact(Character character)
    {
        if (opened == false)
        {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);
        }

    }
}
