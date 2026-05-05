using System;
using UnityEngine;

public class Slot : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject brokenPart;
    [SerializeField] private Part part;
    [SerializeField] private DeliveryMachine deliveryMachineInteract;
    [SerializeField] private Machine machine;
    [SerializeField] private InteractableKill interactableKill;

    public int partIndex;

    public override void Interact()
    {
        //Turn on original good part on machine
        part.Good.SetActive(true);
        Debug.Log("Part installed!");

        //Interactability toggle, turns off machine interaction
        deliveryMachineInteract.gameObject.SetActive(false);

        //In hand state toggle
        player.HideGoodObjectInHand();

        //Unbreak part
        part.IsBroken = false;

        //Add back kill damage
        //interactableKill.KillDamage += 1;

        //Turn off slot interactability
        gameObject.SetActive(false);
    }
}
