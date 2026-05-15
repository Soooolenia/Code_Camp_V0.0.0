using UnityEngine;

public class InitialDoorDrop : MonoBehaviour
{
    //[SerializeField] private AudioSource doorSlam;

    [SerializeField] private DeliveryDoorDrop deliveryDoorDrop;
    private void OnTriggerEnter(Collider other)
    {
        deliveryDoorDrop.DropDoor();
        gameObject.SetActive(false);
        //doorSlam.Play();
    }
}
