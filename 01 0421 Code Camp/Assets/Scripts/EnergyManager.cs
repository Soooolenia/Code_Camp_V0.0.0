using System;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] public float CurrentEnergy = 1f;
    [SerializeField] public float TargetEnergy = 5f;

    [SerializeField] public float EnergyDrainRate;

    [SerializeField] private Machine machine;
    [SerializeField] private ValuePreviewer valuePreviewer;

    [SerializeField] private BrightFlicker brightFlickerBright;
    [SerializeField] private BrightFlicker brightFlickerDark;

    private float lastEnergy;

    private void Start()
    {
        lastEnergy = CurrentEnergy;
    }

    private void EnergyCheck()
    {
        onInteractionTasks();

        int currentFloor = Mathf.FloorToInt(CurrentEnergy);
        int lastFloor = Mathf.FloorToInt(lastEnergy);

        if (currentFloor != lastFloor)
        {
            if (currentFloor < lastFloor)
            {
                OnWholeNumberDropped(currentFloor);
            }
            else if (currentFloor > lastFloor)
            {
                OnWholeNumberIncreased(currentFloor);
            }
        }

        lastEnergy = CurrentEnergy;

        if (CurrentEnergy >= TargetEnergy)
        {
            Debug.Log("Target energy reached!");
        }

        if (CurrentEnergy <= 0f)
        {
            Debug.Log("Energy depleted! Game Over!");
            CurrentEnergy = 0; 
        }
    }

    private void OnWholeNumberIncreased(int newLevel)
    {
        Debug.Log($"Increased! Now at level: {newLevel}");
        brightFlickerBright.BrightenSmall();
    }

    private void OnWholeNumberDropped(int newLevel)
    {
        Debug.Log($"Dropped! Now at level: {newLevel}");
        brightFlickerDark.DarkenSmall();
    }

    private void onInteractionTasks()
    {
        machine.UpdateMachineSmoke();
    }

    public void IncreaseEnergy(float amount)
    {
        Debug.Log($"Energy increased by {amount}");
        CurrentEnergy += amount;

        if (amount >= 0.4f)
        {
            brightFlickerBright.Brighten();
        }
        else
        {
            brightFlickerBright.BrightenSmall();
        }

            //Run Energy Level Check
            EnergyCheck();
    }

    public void DecreaseEnergy(float amount)
    {
        Debug.Log($"Energy decreased by {amount}");
        CurrentEnergy -= amount;

        if (amount <= 0.4f)
        {
            brightFlickerDark.DarkenSmall();
        }
        else
        {
            brightFlickerDark.Darken();
        }
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

    private void LateUpdate()
    {
        CurrentEnergy -= EnergyDrainRate * Time.deltaTime * 0.01f;
        EnergyCheck();
    }
}
