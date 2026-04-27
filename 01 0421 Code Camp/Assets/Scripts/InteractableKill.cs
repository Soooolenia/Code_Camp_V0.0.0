using UnityEngine;

public class InteractableKill : Interactable
{
    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;

    public override void Interact()
    {
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
}
