using Unity.VisualScripting;
using UnityEngine;

public class InteractableRevive : Interactable
{
    [SerializeField] private Monster monster;
    [SerializeField] private Machine machine;

    [SerializeField] private Animator animator;

    [SerializeField] private EnergyManager energyManager;
    public override void Interact()
    {
        //Check if the monster is alive
        //If alive, revive
        //If not, debug log "Monster is already alive!"

        if (!machine.MachineIsWorking)
        {
            Debug.Log("The machine is broken!");
            return;
        }

        if (monster.IsAlive == true)
        {
            Debug.Log("Monster is already alive!");
            return;
        }

        monster.Revive();
        animator.SetTrigger("Revive");

        energyManager.DecreaseEnergy();

        //Decide if parts break or not
        if (Random.value < 0.5f)
        {
            machine.BreakParts();
        }
    }
}
