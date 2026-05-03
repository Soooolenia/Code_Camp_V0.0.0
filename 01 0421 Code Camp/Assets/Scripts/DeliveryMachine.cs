using System;
using UnityEngine;

public class DeliveryMachine : Interactable
{
    [SerializeField] private Player player;

    [SerializeField] private EnergyManager energyManager;
    public override void Interact()
    {  
        Debug.Log("Picked up good part!");

        //Finding the slots
        Slot slot = player.GetSlotToRepair();

        //In hand display toggle
        player.HideBadObjectInHand();
        //player.ShowGoodObjectInHand(slot.partIndex);
        player.ShowGoodObjectInMachine(slot.partIndex);

        //Toggle off delivery machine interactability
        gameObject.SetActive(false);

        energyManager.DecreaseMoreEnergy();
    }
}
