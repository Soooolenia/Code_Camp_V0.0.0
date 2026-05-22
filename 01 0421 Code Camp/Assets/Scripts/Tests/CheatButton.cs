using UnityEngine;

public class CheatButton : Interactable
{
    [SerializeField] private EnergyManager energyManager;
    public override void Interact()
    {
        energyManager.IncreaseEnergy(1f);
    }
}
