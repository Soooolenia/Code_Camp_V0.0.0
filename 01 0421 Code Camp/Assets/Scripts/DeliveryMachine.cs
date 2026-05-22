using System;
using System.Threading.Tasks;
using UnityEngine;

public class DeliveryMachine : Interactable
{
    [SerializeField] private Player player;

    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private DeliveryIndicator deliveryIndicator;

    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorL;

    [SerializeField] private AudioSource partInserted;
    [SerializeField] private AudioSource delivering;
    [SerializeField] private AudioSource partsDelivered;
    [SerializeField] private AudioSource rightHatchClose;
    [SerializeField] private AudioSource leftHatchOpen;
    
    public override async void Interact()
    {
        //Close Hatch
        animator.SetTrigger("Close");
        rightHatchClose.Play();

        partInserted.Play();
        
        if (!delivering.isPlaying)
        {
            delivering.Play();
        }

        energyManager.DecreaseEnergy(0.65f);
        //Debug.Log("Parts delivering!");
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
        //Open Left hatch
        animatorL.SetTrigger("Open");
        leftHatchOpen.Play();

        partsDelivered.Play();

        if (delivering.isPlaying)
        {
            delivering.Stop();
        }

        //Toggle off delivery machine interactability
        gameObject.SetActive(false);
    }
}
