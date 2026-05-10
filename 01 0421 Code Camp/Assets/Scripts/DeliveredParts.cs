using UnityEngine;

public class DeliveredParts : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private DeliveryIndicator indicator;
    public override void Interact()
    {
        Debug.Log($"Picked up {gameObject.name}");

        Slot slot = player.GetSlotToRepair();
        slot.gameObject.SetActive(true);
        player.ShowGoodObjectInHand(slot.partIndex);
        player.HideGoodObjectInMachine();
        indicator.Off();

        gameObject.SetActive(false);
    }
}
