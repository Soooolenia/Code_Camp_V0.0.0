using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private InteractablePartA partA;
    [SerializeField] private InteractablePartB partB;
    [SerializeField] private InteractablePartC partC;

    [SerializeField] private List<GameObject> goodParts;

    private void Awake()
    {
        //Puts parts into list
        goodParts = GameObject.FindGameObjectsWithTag("Parts").ToList();
    }
    public void BreakParts()
    {
        //Look into the good parts list
        //Randomly select one and break
        //Remove that one from list

        if (goodParts.Count != 0)
        {
            //Get list length and select one
            int randomIndex = Random.Range(0, goodParts.Count);

            //Access part, and execute function within
        }
    }
}
