using UnityEngine;

public class InteractableKill : Interactable
{
    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private Machine machine;

    [SerializeField] private Animator animator;

    public override void Interact()
    {
        if (!machine.MachineIsWorking)
        {
            Debug.Log("The machine is broken!");
            return;
        }

        //Check if the monster is alive
        if (monster.IsAlive == false)
        {
            Debug.Log("Monster is already dead!");
            return;
        }
        //Kill the monster
        monster.Kill();
        animator.SetTrigger("Kill");

        energyManager.IncreaseEnergy();

        //Decide if parts break or not
        if (Random.value < 0.5f)
        {
            machine.BreakParts();
        }
    }
}
