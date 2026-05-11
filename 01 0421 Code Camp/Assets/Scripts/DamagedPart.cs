using System;
using UnityEngine;

public class DamagedPart : Interactable
{
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject broken;

    [SerializeField] private Part part;
    [SerializeField] private InteractableKill interactableKill;

    [SerializeField] private EnergyManager energyManager;

    [SerializeField] private float repairProgress = 0;
    public override void Interact()
    {
        repairProgress += 0.1f;
        if (repairProgress >= 1)
        {
            repair();
        }
    }

    private void repair()
    {
        good.SetActive(true);
        broken.SetActive(false);
        gameObject.SetActive(false);

        part.IsDamaged = false;
        //interactableKill.KillDamage += 1;
        energyManager.DecreaseEnergy();

        Debug.Log($"{gameObject.name} has been repaired!");
    }
}
