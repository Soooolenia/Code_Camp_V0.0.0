using System;
using UnityEngine;

public class DeliveryMachine : Interactable
{
    [SerializeField] private Player player;
    public override void Interact()
    {  
        Debug.Log("Picked up good part!");

        //Finding the slot to toggle, and toggle on interactivity
        player.GetSlotToRepair().gameObject.SetActive(true);
        Debug.Log("Slot is now interactable!");

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
