using UnityEngine;

public class BrokenPart : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private DeliveryMachine deliveryMachineInteract;
    public override void Interact()
    {
        //In hand state toggle
        player.BrokenPartInHand = true;
        player.ShowBadObjectInHand();
        Debug.Log("Picked up broken part.");

        //Disable damaged part
        gameObject.SetActive(false);

        //Turn on delivery machine
        deliveryMachineInteract.gameObject.SetActive(true);

    }
}
