using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Machine : MonoBehaviour
{
    //[SerializeField] private InteractablePartA partA;
    //[SerializeField] private InteractablePartB partB;
    //[SerializeField] private InteractablePartC partC;

    [SerializeField] private List<Part> parts;
    [SerializeField] private Part partA;
    [SerializeField] private Part partB;
    [SerializeField] private Part partC;

    [SerializeField] private InteractableKill InteractableKill;

    [SerializeField] private ParticleSystem machineSmoke;

    //private bool MachineIsWorking = true;

    private void Start()
    {
        var foundComponents = GetComponentsInChildren<Part>();

        foreach (Part part  in foundComponents)
        {
            parts.Add(part);
        }
    }
    public void BreakParts()
    {
        var partsChosen = parts[Random.Range(0, parts.Count)];

        partsChosen.DamagePart();
        //partsChosen.DamageCounter();
    }

    public void DamageCounter()
    {
        partA.DamageCounter();
        partB.DamageCounter();
        partC.DamageCounter();
    }

    public bool IsBroken()
    {
        bool everyPartIsDamaged = partA.IsDamaged && partB.IsDamaged && partC.IsDamaged;

        bool anyPartIsBroken = partA.IsBroken || partB.IsBroken || partC.IsBroken;

        bool killDamageIsZero = InteractableKill.KillDamage <= 0;

        bool machineIsBroken = everyPartIsDamaged || anyPartIsBroken || killDamageIsZero;
        return machineIsBroken;
    }

    private void Update()
    {
        if(IsBroken())
        {
            machineSmoke.Play();
        }
        else
        {
            machineSmoke.Stop();
        }
    }
}
