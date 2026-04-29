using System.Collections.Generic;
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

    public bool MachineIsWorking = true;

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
        //Decide which one to break
        //Call break function in part

        //if (Random.value < 0.33f)
        //{
        //    partA.DamagePartA();
        //}
        //else if (Random.value < 0.66f)
        //{
        //    partB.DamagePartB();
        //}
        //else
        //{
        //    partC.DamagePartC();
        //}

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

    //CUSTOM FUNCTION MACHINE - Run CUSTOM FUNCTION PART A (and B and C)
}
