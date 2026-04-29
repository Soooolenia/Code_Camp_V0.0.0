using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Machine machine;
    [SerializeField] private InteractableKill kill;

    [SerializeField] GameObject monsterAlive;
    [SerializeField] GameObject monsterDead;

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

            monsterAlive.gameObject.SetActive(false);
            monsterDead.gameObject.SetActive(true);

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

        monsterAlive.gameObject.SetActive(true);
        monsterDead.gameObject.SetActive(false);

        monsterHealth = 3;
        Debug.Log("Monster has been revived!");

        machine.DamageCounter();

        // TODO: Add revival animation or effects here
    }
}
