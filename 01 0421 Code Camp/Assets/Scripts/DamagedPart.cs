using System.Collections;
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
        hudManager.ShowDamagedPartUI();
        repairProgress = 0;
    }

    public override void InteractHold()
    {
        repairProgress += 0.5f * Time.deltaTime;

        if (repairProgress >= 1)
        {
            repair();
            repairProgress = 0;
        }
    }

    public override void InteractStop()
    {
        StartCoroutine(ReduceRepairProgress());
    }

    public override void HoverStay()
    {
        hudManager.DamagedPartUIUpdate(repairProgress);
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

    private IEnumerator ReduceRepairProgress()
    {
        while (repairProgress > 0)
        {
            repairProgress -= 0.5f * Time.deltaTime;
            yield return null;
        }
        repairProgress = 0;
    }
}
