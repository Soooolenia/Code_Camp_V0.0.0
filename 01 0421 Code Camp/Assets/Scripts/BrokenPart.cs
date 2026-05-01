using UnityEngine;

public class BrokenPart : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private DeliveryMachine deliveryMachineInteract;

    [SerializeField] private Slot slot;
    public override void Interact()
    {
        //In hand state toggle
        player.BrokenPartInHand = true;
        player.ShowBadObjectInHand();
        player.SetTargetSlotForReplacement(slot);
        Debug.Log("Picked up broken part.");

        //Disable damaged part
        gameObject.SetActive(false);

        //Turn on delivery machine
        deliveryMachineInteract.gameObject.SetActive(true);

    }
}
