using System;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] public float CurrentEnergy = 1f;
    [SerializeField] public float TargetEnergy = 5f;

    [SerializeField] public float EnergyDrainRate = 1f;

    private void EnergyCheck()
    {
        if (CurrentEnergy >= TargetEnergy)
        {
            Debug.Log("Target energy reached!");
        }

        if (CurrentEnergy <= 0f)
        {
            Debug.Log("Energy depleted! Game Over!");
        }
    }

    public void IncreaseEnergy()
    {
        Debug.Log("Energy increased by 1");
        CurrentEnergy += 1f;

        //Run Energy Level Check
        EnergyCheck();
    }

    public void DecreaseEnergy()
    {
        Debug.Log("Energy decreased by 0.3");
        CurrentEnergy -= 0.3f;
        //Run Energy Level Check
        EnergyCheck();
    }

    public void DecreaseMoreEnergy()
    {
        Debug.Log("Energy decreased by 0.7");
        CurrentEnergy -= 0.7f;
        //Run Energy Level Check
        EnergyCheck();
    }

    private void Update()
    {
        CurrentEnergy -= EnergyDrainRate * Time.deltaTime * 0.0001f;
        EnergyCheck();
    }
}
