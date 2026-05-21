using UnityEngine;

public class InitialDoorDrop : MonoBehaviour
{
    //[SerializeField] private AudioSource doorSlam;

    [SerializeField] private DeliveryDoorDrop deliveryDoorDrop;
    [SerializeField] private AudioSource deliveryDoorBreak;
    private void OnTriggerEnter(Collider other)
    {
        deliveryDoorDrop.DropDoor();
        gameObject.SetActive(false);
        deliveryDoorBreak.Play();

        //doorSlam.Play();
    }
}
