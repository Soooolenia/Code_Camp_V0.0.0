using System.Collections.Generic;
using Unity.VisualScripting;
using System.Threading.Tasks;
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

    [SerializeField] private AudioSource breakDown;
    [SerializeField] private AudioSource start;
    [SerializeField] private AudioSource operation;

    [SerializeField] private EnergyManager energyManager;

    private bool wasBrokenLastCheck = false;

    private void Start()
    {
        operation.Play();

        var foundComponents = GetComponentsInChildren<Part>();

        foreach (Part part in foundComponents)
        {
            parts.Add(part);
        }

        wasBrokenLastCheck = IsBroken();
    }
    public void BreakParts()
    {
        var partsChosen = parts[Random.Range(0, parts.Count)];

        if (Random.value < 0.2f)
        {
            if (energyManager.CurrentEnergy >= 2)
            {
                partsChosen.BreakPartFr();
            }
        }
        else
        {
            partsChosen.DamagePart();
        }
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

    public async void UpdateMachineSmoke()
    {
        bool currentlyBroken = IsBroken();

        //Machine broke down this frame
        if (currentlyBroken && !wasBrokenLastCheck)
        {
            if (!machineSmoke.isPlaying) machineSmoke.Play();

            breakDown.Play();
            operation.Stop();

            wasBrokenLastCheck = true; 
        }
        //Machine got fixed this frame
        else if (!currentlyBroken && wasBrokenLastCheck)
        {
            wasBrokenLastCheck = false;

            if (machineSmoke.isPlaying) machineSmoke.Stop();

            start.Play();

            await Task.Delay(2750);
            operation.Play();

            //wasBrokenLastCheck = false; 
        }
    }
}
