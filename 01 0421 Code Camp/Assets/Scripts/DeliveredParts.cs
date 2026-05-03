using UnityEngine;

public class DeliveredParts : Interactable
{
    [SerializeField] private Player player;
    public override void Interact()
    {
        Debug.Log($"Picked up {gameObject.name}");

        Slot slot = player.GetSlotToRepair();
        slot.gameObject.SetActive(true);
        player.ShowGoodObjectInHand(slot.partIndex);
        player.HideGoodObjectInMachine();

        gameObject.SetActive(false);
    }
}
