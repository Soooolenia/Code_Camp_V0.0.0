using System;
using UnityEditor.UI;
using UnityEngine;

public class DamagedPart : Interactable
{
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject broken;

    [SerializeField] private Part part;
    [SerializeField] private InteractableKill interactableKill;
    public override void Interact()
    {
        repair();
    }

    private void repair()
    {
        good.SetActive(true);
        broken.SetActive(false);
        gameObject.SetActive(false);

        part.IsDamaged = false;
        interactableKill.KillDamage += 1;

        Debug.Log($"{gameObject.name} has been repaired!");
    }
}
