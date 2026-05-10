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
        deliveryIndicator.On();

        //Finding the slots
        Slot slot = player.PeekSlotToRepair();

        //In hand display toggle
        player.HideBadObjectInHand();
        //player.ShowGoodObjectInHand(slot.partIndex);

        await Task.Delay(2000);
        player.ShowGoodObjectInMachine(slot.partIndex);

        //Toggle off delivery machine interactability
        gameObject.SetActive(false);

        energyManager.DecreaseMoreEnergy();
    }
}
