using System.IO;
using UnityEngine;

public class ValuePreviewer : MonoBehaviour
{
    [Header("Energy Level")]
    [SerializeField] private float currentEnergyLevel;
    [SerializeField] private float targetEnergyLevel;
    [SerializeField] private float energyDrainRate;

    [Header("Monster State")]
    [SerializeField] private bool isMonsterAlive;
    [SerializeField] private int monsterHealth;
    
    [Header("Machine State")]
    [SerializeField] private bool isMachineWorking;
    [SerializeField] private int killDamage;
    [Header("")]
    [SerializeField] private bool isPartADamaged;
    [SerializeField] private bool isPartABroken;
    [SerializeField] private int partADamageLevel;
    [SerializeField] private bool isPartBDamaged;
    [SerializeField] private bool isPartBBroken;
    [SerializeField] private int partBDamageLevel;
    [SerializeField] private bool isPartCDamaged;
    [SerializeField] private bool isPartCBroken;
    [SerializeField] private int partCDamageLevel;
    [Header("")]
    [SerializeField] private float constrainADamage;
    [SerializeField] private float constrainBDamage;

    [Header("References")]
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private Monster monster;
    [SerializeField] private Machine machine;
    [SerializeField] private Part partA;
    [SerializeField] private Part partB;    
    [SerializeField] private Part partC;
    [SerializeField] private InteractableKill interactableKill;
    [SerializeField] private Constrain constrainA;
    [SerializeField] private Constrain constrainB;

    public void Update()
    {
        currentEnergyLevel = energyManager.CurrentEnergy;
        targetEnergyLevel = energyManager.TargetEnergy;
        energyDrainRate = energyManager.EnergyDrainRate;

        isMonsterAlive = monster.IsAlive;
        monsterHealth = monster.MonsterHealth;

        isMachineWorking = !machine.IsBroken();
        isPartADamaged = partA.IsDamaged;
        isPartABroken = partA.IsBroken;
        partADamageLevel = partA.DamageLevel;
        isPartBDamaged = partB.IsDamaged;
        isPartBBroken = partB.IsBroken;
        partBDamageLevel = partB.DamageLevel;
        isPartCDamaged = partC.IsDamaged;
        isPartCBroken = partC.IsBroken;
        partCDamageLevel = partC.DamageLevel;
        killDamage = interactableKill.KillDamage;

        constrainADamage = constrainA.damage;
        constrainBDamage = constrainB.damage;
    }

}
