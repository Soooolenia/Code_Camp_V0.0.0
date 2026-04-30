using System;
using UnityEngine;

public class SlotA : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject brokenPart;
    [SerializeField] private Part part;
    [SerializeField] private DeliveryMachine deliveryMachineInteract;
    [SerializeField] private Machine machine;
    public override void Interact()
    {
        //Turn on original good part on machine
        part.Good.SetActive(true);
        Debug.Log("Part installed!");

        //Interactability toggle, turns off machine interaction
        deliveryMachineInteract.gameObject.SetActive(false);

        //In hand state toggle
        player.GoodPartInHand = false;
        player.HideGoodObjectInHand();

        //unbreak machine, unbreak part
        machine.MachineIsWorking = true;
        part.IsBroken = false;

        //Turn off slot A interactability
        gameObject.SetActive(false);
    }
}
