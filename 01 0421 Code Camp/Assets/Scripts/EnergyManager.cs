using System;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] public float CurrentEnergy = 1f;
    [SerializeField] public float TargetEnergy = 5f;

    [SerializeField] public float EnergyDrainRate;

    [SerializeField] private Machine machine;
    [SerializeField] private ValuePreviewer valuePreviewer;

    private void EnergyCheck()
    {
        onInteractionTasks();

        if (CurrentEnergy >= TargetEnergy)
        {
            Debug.Log("Target energy reached!");
        }

        if (CurrentEnergy <= 0f)
        {
            Debug.Log("Energy depleted! Game Over!");
        }
    }

    private void onInteractionTasks()
    {
        machine.UpdateMachineSmoke();
        valuePreviewer.UpdateValues();
    }

    public void IncreaseEnergy(float amount)
    {
        Debug.Log($"Energy increased by {amount}");
        CurrentEnergy += amount;

        //Run Energy Level Check
        EnergyCheck();
    }

    public void DecreaseEnergy(float amount)
    {
        Debug.Log($"Energy decreased by {amount}");
        CurrentEnergy -= amount;
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
