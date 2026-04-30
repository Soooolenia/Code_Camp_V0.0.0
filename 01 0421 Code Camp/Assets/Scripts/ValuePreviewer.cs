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
    [SerializeField] private bool isPartADamaged;
    [SerializeField] private bool isPartBDamaged;
    [SerializeField] private bool isPartCDamaged;
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
        isPartBDamaged = partB.IsDamaged;
        isPartCDamaged = partC.IsDamaged;
        killDamage = interactableKill.KillDamage;
    }

}
