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

    [SerializeField] private AudioSource repairing;
    [SerializeField] private AudioSource repaired;

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public override void Interact()
    {
        hudManager.ShowDamagedPartUI();
        repairProgress = 0;
    }

    public override void InteractHold()
    {
        repairProgress += 0.5f * Time.deltaTime;

        if (!repairing.isPlaying)
        {
            repairing.Play();
        }

        if (repairProgress >= 1)
        {
            repair();
            repairProgress = 0;

            repairing.Stop();
            repaired.Play();
        }
    }

    public override void InteractStop()
    {
        if (repairing.isPlaying)
        {
            repairing.Stop();
        }

        if (!gameObject.activeSelf)
        {
            return;
        }

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
        energyManager.DecreaseEnergy(0.1f);

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
