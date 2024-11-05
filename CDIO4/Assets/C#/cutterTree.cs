using UnityEngine;

public class cutterTree : Interact_hit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropItems = 5;
    [SerializeField] float spread = 0.7f;
    public override void Hit()
    {
        while (dropItems > 0) {
            dropItems--;
            Vector3 position = transform.position;
            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;
        }

        Destroy(gameObject);
    }
}
