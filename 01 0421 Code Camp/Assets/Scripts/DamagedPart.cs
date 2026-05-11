using System;
using UnityEngine;
using UnityEngine.UI;

public class DamagedPart : Interactable
{
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject broken;

    [SerializeField] private Part part;
    [SerializeField] private InteractableKill interactableKill;

    [SerializeField] private EnergyManager energyManager;

    [SerializeField] private GameObject radialUI;

    [SerializeField] private float repairProgress = 0;
    public override void Interact()
    {
        //radialUI.SetActive(true);

        repairProgress += 0.1f;
        if (repairProgress >= 1)
        {
            repair();
            repairProgress = 0;
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
