using System;
using UnityEngine;

public class DeliveryMachine : Interactable
{
    [SerializeField] private Player player;

    [SerializeField] private EnergyManager energyManager;
    public override void Interact()
    {  
        Debug.Log("Picked up good part!");

        //Finding the slot to toggle, and toggle on interactivity
        Slot slot = player.GetSlotToRepair();
        slot.gameObject.SetActive(true);
        Debug.Log("Slot is now interactable!");

        //In hand display toggle
        player.HideBadObjectInHand();
        player.ShowGoodObjectInHand(slot.partIndex);

        //Toggle off delivery machine interactability
        gameObject.SetActive(false);

        energyManager.DecreaseMoreEnergy();
    }
}
