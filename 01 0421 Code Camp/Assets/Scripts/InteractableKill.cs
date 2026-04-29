using UnityEngine;

public class InteractableKill : Interactable
{
    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private Machine machine;

    [SerializeField] private Animator animator;

    [SerializeField] private Part partA;
    [SerializeField] private Part partB;
    [SerializeField] private Part partC;

    [SerializeField] public int KillDamage = 3;

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

        //If a part is damaged, have the machine take 1 less damage
        //if (partA.IsDamaged)
        //{
        //    KillDamage -= 1;
        //    Debug.Log("Part A reduced kill damage by 1");
        //}

        //if (partB.IsDamaged)
        //{
        //    KillDamage -= 1;
        //    Debug.Log("Part B reduced kill damage by 1");
        //}

        //if (partC.IsDamaged)
        //{
        //    KillDamage -= 1;
        //    Debug.Log("Part C reduced kill damage by 1");
        //}

        //Decide if parts break or not
        if (Random.value < 0.5f)
        {
            machine.BreakParts();
        }
    }
}
