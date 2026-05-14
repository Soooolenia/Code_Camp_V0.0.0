using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Machine machine;
    [SerializeField] private InteractableKill kill;

    [SerializeField] GameObject monsterAlive;
    [SerializeField] GameObject monsterDead;

    [SerializeField] private EnergyManager energyManager;

    [SerializeField] public bool isAlive = false;

    public bool IsAlive => isAlive;

    [SerializeField] public int MonsterHealth = 0;
    public void Kill()
    {
        if (!isAlive)
        {
            Debug.Log("Monster is already dead!");
            return;
        }

        MonsterHealth = MonsterHealth - kill.KillDamage;

        if (MonsterHealth <= 0)
        {
            isAlive = false;

            monsterAlive.gameObject.SetActive(false);
            monsterDead.gameObject.SetActive(true);

            Debug.Log("Monster has been killed!");
            machine.DamageCounter();
            energyManager.IncreaseEnergy();

        }

        else
        {
            Debug.Log($"Monster current health: {MonsterHealth}");
        }

        // TODO: Add death animation or effects here
    }

    public void Revive()
    {
        if (isAlive)
        {
            Debug.Log("Monster is already alive!");
            return;
        }

        isAlive = true;

        monsterAlive.gameObject.SetActive(true);
        monsterDead.gameObject.SetActive(false);

        MonsterHealth = 3;
        Debug.Log("Monster has been revived!");

        machine.DamageCounter();

        // TODO: Add revival animation or effects here
    }
}
