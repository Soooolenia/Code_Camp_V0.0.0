using System;
using System.Threading.Tasks;
using UnityEngine;

public class DeliveryMachine : Interactable
{
    [SerializeField] private Player player;

    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private DeliveryIndicator deliveryIndicator;
    public override async void Interact()
    {  
        Debug.Log("Parts delivering!");
        deliveryIndicator.InProgress();

        //Finding the slots
        Slot slot = player.PeekSlotToRepair();

        //In hand display toggle
        player.HideBadObjectInHand();
        //player.ShowGoodObjectInHand(slot.partIndex);

        await Task.Delay(5000);
        if (this == null) return;
        player.ShowGoodObjectInMachine(slot.partIndex);
        deliveryIndicator.InProgressStop();
        deliveryIndicator.On();

        //Toggle off delivery machine interactability
        gameObject.SetActive(false);

        energyManager.DecreaseEnergy(0.65f);
    }
}
