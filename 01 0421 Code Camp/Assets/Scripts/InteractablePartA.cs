using System;
using UnityEngine;

public class InteractablePartA : MonoBehaviour
{
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject damaged;
    [SerializeField] private GameObject broken;

    private bool isDamaged = false;

    private int damagedCounter = 0;

    private void Awake()
    {
        good.SetActive(true);
        damaged.SetActive(false);
        broken.SetActive(false);
    }
    public void DamagePartA()
    {
        if (isDamaged == false)
        {
            Debug.Log("Part A broke!");
            good.SetActive(false);
            damaged.SetActive(true);

            isDamaged = true;
            //startDamagedCounter();
        }
        else
        {
            Debug.Log("Part A is already damaged!");
        }
    }

    public void DamageCounter()
    {
        //If part is broken, add one to damage counter
        //If part is not broken, set damage counter back to 0

        if (isDamaged)
        {
            damagedCounter += 1;
            Debug.Log($"Damage level: {damagedCounter}");
            
            if(damagedCounter >= 2)
            {
                good.SetActive(false);
                damaged.SetActive(true);
                broken.SetActive(true);
                Debug.Log("Part A is broken!");
            }
        }
        else
        {
            damagedCounter = 0;
        }
    }

    //CUSTOM FUNCTION PART A - if the object is damaged, count up how many times it has been used, then break after enough uses
}
