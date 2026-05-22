using System;
using Unity.VisualScripting;
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

    [SerializeField] private WinLoseManager winLoseManager;

    [SerializeField] private MusicManager musicManager;

    [Header("Energy use")]
    [SerializeField] private AudioSource energyUsedHigh;
    [SerializeField] private AudioSource energyUsedMid;
    [SerializeField] private AudioSource energyUsedLow;

    [Header("Energy gain")]
    [SerializeField] private AudioSource energyGainedHigh;
    [SerializeField] private AudioSource energyGainedLow;
    [SerializeField] private AudioSource energyFull;

    private bool isGameStarted = false;
    private bool isGameOver = false;

    private float lastEnergy;

    private void Start()
    {
        lastEnergy = CurrentEnergy;
    }

    private void EnergyCheck()
    {
        onInteractionTasks();

        if (CurrentEnergy < 1f)
        {
            musicManager.StartDangerLoop();
        }
        else if (CurrentEnergy >= 1f)
        {
            musicManager.StartDarkHearts();
        }

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
            if (isGameOver == true) { return; }
            isGameOver = true;

            Debug.Log("Target energy reached!");
            energyFull.Play();
            winLoseManager.Win();
        }

        if (CurrentEnergy <= 0f)
        {
            if (isGameOver == true) { return; }
            isGameOver = true;

            Debug.Log("Energy depleted! Game Over!");
            CurrentEnergy = 0; 
            winLoseManager.DeathByEscapedMonster();
        }
    }

    private void OnWholeNumberIncreased(int newLevel)
    {
        Debug.Log($"Increased! Now at level: {newLevel}");
        brightFlickerBright.BrightenSmall();
        energyGainedHigh.Play();
    }

    private void OnWholeNumberDropped(int newLevel)
    {
        Debug.Log($"Dropped! Now at level: {newLevel}");
        brightFlickerDark.DarkenSmall();
        energyUsedMid.Play();
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
            energyGainedHigh.Play();
        }
        else
        {
            brightFlickerBright.BrightenSmall();
            energyGainedLow.Play();
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
            energyUsedLow.Play();
        }
        else
        {
            brightFlickerDark.Darken();
            energyGainedHigh.Play();
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
        if (isGameStarted == false) { return; }

        CurrentEnergy -= EnergyDrainRate * Time.deltaTime * 0.01f;
        EnergyCheck();
    }

    public void startGame()
    {
        if(isGameStarted == true) { return; }

        isGameStarted = true;
    }
}
