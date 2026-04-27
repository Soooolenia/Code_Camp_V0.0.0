using UnityEngine;

public class InteractableKill : Interactable
{
    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private Machine machine;

    public override void Interact()
    {
        //Check if the monster is alive
        if (monster.IsAlive == false)
        {
            Debug.Log("Monster is already dead!");
            return;
        }

        energyManager.IncreaseEnergy();

        //Kill the monster
        monster.Kill();

        //Decide if parts break or not
        if (Random.value < 0.5f)
        {
            machine.BreakParts();
        }

    }
}
