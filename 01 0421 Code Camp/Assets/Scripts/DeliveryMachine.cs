using System;
using UnityEngine;

public class DeliveryMachine : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] SlotA slotAInteraction;
    public override void Interact()
    {  
        Debug.Log("Picked up good part!");

        //Toggle on slot A interactability
        slotAInteraction.gameObject.SetActive(true);
        Debug.Log("Slot A is now interactable!");

        //In hand state toggle
        player.GoodPartInHand = true;
        player.BrokenPartInHand = false;

        //In hand display toggle
        player.HideBadObjectInHand();
        player.ShowGoodObjectInHand();

        //Toggle off delivery machine interactability
        gameObject.SetActive(false);
    }
}
