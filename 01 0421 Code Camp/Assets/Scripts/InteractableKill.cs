using UnityEngine;

public class InteractableKill : Interactable
{
    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;

    public override void Interact()
    {
        //Decide parts break or not
        if (Random.value < 0.5f)
        {
            BreakParts();
        }

        //Check if the monster is alive
        if (monster.IsAlive == false)
        {
            Debug.Log("Monster is dead!");
            return;
        }

        energyManager.IncreaseEnergy();

        //Kill the monster
        monster.Kill();
    }

    private static void BreakParts()
    {
       
        //Decide which one to break
        //Call break function in part

        if (Random.value < 0.33f)
        {
            Debug.Log("Part A broke!");
        }
        else if (Random.value < 0.66f)
        {
            Debug.Log("Part B broke!");
        }
        else
        {
            Debug.Log("Part C broke!");
        }
    }
}
