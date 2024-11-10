using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
}
