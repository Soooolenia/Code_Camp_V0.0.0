using UnityEngine;

public class DeliveredParts : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private DeliveryIndicator indicator;

    [SerializeField] private AudioSource leftHatchClose;
    [SerializeField] private AudioSource partsPickup;

    [SerializeField] private Animator animator;
    public override void Interact()
    {
        Debug.Log($"Picked up {gameObject.name}");

        Slot slot = player.GetSlotToRepair();
        slot.gameObject.SetActive(true);
        player.ShowGoodObjectInHand(slot.partIndex);
        player.HideGoodObjectInMachine();
        indicator.Off();

        partsPickup.Play();

        //Close Hatch
        animator.SetTrigger("Close");
        leftHatchClose.Play();

        gameObject.SetActive(false);
    }
}
