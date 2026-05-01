using UnityEngine;

public class ValuePreviewer : MonoBehaviour
{
    [Header("Energy Level")]
    [SerializeField] private float currentEnergyLevel;
    [SerializeField] private float targetEnergyLevel;

    [Header("Monster State")]
    [SerializeField] private bool isMonsterAlive;
    [SerializeField] private int monsterHealth;
    
    [Header("Machine State")]
    [SerializeField] private bool isMachineWorking;
    [Header("")]
    [SerializeField] private bool isPartADamaged;
    [SerializeField] private bool isPartABroken;
    [SerializeField] private bool isPartBDamaged;
    [SerializeField] private bool isPartBBroken;
    [SerializeField] private bool isPartCDamaged;
    [SerializeField] private bool isPartCBroken;
    [SerializeField] private int killDamage;

    [Header("References")]
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private Monster monster;
    [SerializeField] private Machine machine;
    [SerializeField] private Part partA;
    [SerializeField] private Part partB;    
    [SerializeField] private Part partC;
    [SerializeField] private InteractableKill interactableKill;
    private void Update()
    {
        currentEnergyLevel = energyManager.CurrentEnergy;
        targetEnergyLevel = energyManager.TargetEnergy;

        isMonsterAlive = monster.IsAlive;
        monsterHealth = monster.MonsterHealth;

        isMachineWorking = machine.MachineIsWorking;
        isPartADamaged = partA.IsDamaged;
        isPartABroken = partA.IsBroken;
        isPartBDamaged = partB.IsDamaged;
        isPartBBroken = partB.IsBroken;
        isPartCDamaged = partC.IsDamaged;
        isPartCBroken = partC.IsBroken;
        killDamage = interactableKill.KillDamage;
    }

}
