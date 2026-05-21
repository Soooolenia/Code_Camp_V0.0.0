using UnityEngine;

public class BrokenPart : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private DeliveryMachine deliveryMachineInteract;
    [SerializeField] private Animator animator;

    [SerializeField] private Slot slot;

    public override void Interact()
    {
        //In hand state toggle
        player.ShowBadObjectInHand(slot.partIndex);
        player.SetTargetSlotForReplacement(slot);
        Debug.Log("Picked up broken part.");

        //Disable damaged part
        gameObject.SetActive(false);

        //Turn on delivery machine
        deliveryMachineInteract.gameObject.SetActive(true);

        //Play right cap animation to open hatch
        animator.SetTrigger("Open");
    }
}
