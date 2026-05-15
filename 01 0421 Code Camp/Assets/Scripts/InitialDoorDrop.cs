using UnityEngine;

public class InitialDoorDrop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private DeliveryDoorFix deliveryDoorFix;
    [SerializeField] private DeliveryDoorManager deliveryDoorManager;

    [SerializeField] private HUDManager hudManager;

    [SerializeField] private DeliveryDoorDrop deliveryDoorDrop;
    private void OnTriggerEnter(Collider other)
    {
        deliveryDoorDrop.DropDoor();
        gameObject.SetActive(false);
    }
}
