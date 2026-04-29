using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Machine machine;
    [SerializeField] InteractableKill kill;

    [SerializeField] private bool isAlive = true;

    public bool IsAlive => isAlive;

    [SerializeField] private int monsterHealth = 3;
    public void Kill()
    {
        if (!isAlive)
        {
            Debug.Log("Monster is already dead!");
            return;
        }

        monsterHealth = monsterHealth - kill.KillDamage;

        if (monsterHealth <= 0)
        {
            isAlive = false;
            Debug.Log("Monster has been killed!");
            machine.DamageCounter();
        }

        else
        {
            Debug.Log($"Monster current health: {monsterHealth}");
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
        monsterHealth = 3;
        Debug.Log("Monster has been revived!");

        machine.DamageCounter();

        // TODO: Add revival animation or effects here
    }
}
