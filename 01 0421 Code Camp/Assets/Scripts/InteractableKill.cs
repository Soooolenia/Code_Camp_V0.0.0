using UnityEngine;

public class InteractableKill : Interactable
{
    public bool IsMonsterAlive = true;
    public override void Interact()

    {
        //Check if the monster is alive
        if (IsMonsterAlive == false)
        {
            Debug.Log("Monster is dead!");
            return;
        }

        IncreaseEnergy();
        //Kill the monster
        IsMonsterAlive = false;
    }

    private void IncreaseEnergy()
    {
        Debug.Log("Energy increased by 1");
        FindAnyObjectByType<EnergyManager>().CurrentEnergy += 1f;

        //Run Energy Level Check
        FindAnyObjectByType<EnergyManager>().EnergyCheck();
    }
}
