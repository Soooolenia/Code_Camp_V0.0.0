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

    [SerializeField] private Image radialUI;
    [SerializeField] private HUDManager hudManager;

    [SerializeField] private float repairProgress = 0;
    public override void Interact()
    {
        repairProgress += 0.1f;
        //radialUI.gameObject.SetActive(true);
        hudManager.ShowDamagedPartUI();
        hudManager.DamagedPartUIUpdate(repairProgress);
        
        if (repairProgress >= 1)
        {
            repair();
            repairProgress = 0;
            hudManager.DamagedPartUIUpdate(repairProgress);
        }
    }

    private void repair()
    {
        good.SetActive(true);
        broken.SetActive(false);
        gameObject.SetActive(false);
        //radialUI.gameObject.SetActive(false);
        hudManager.HideDamagedPartUI();

        part.IsDamaged = false;
        //interactableKill.KillDamage += 1;
        energyManager.DecreaseEnergy();

        Debug.Log($"{gameObject.name} has been repaired!");
    }
}
