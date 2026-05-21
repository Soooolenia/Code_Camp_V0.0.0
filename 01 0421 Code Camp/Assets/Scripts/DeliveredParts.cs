using UnityEngine;

public class DeliveredParts : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private DeliveryIndicator indicator;

    [SerializeField] private Animator animator;
    public override void Interact()
    {
        Debug.Log($"Picked up {gameObject.name}");

        Slot slot = player.GetSlotToRepair();
        slot.gameObject.SetActive(true);
        player.ShowGoodObjectInHand(slot.partIndex);
        player.HideGoodObjectInMachine();
        indicator.Off();

        //Close Hatch
        animator.SetTrigger("Close");

        gameObject.SetActive(false);
    }
}
