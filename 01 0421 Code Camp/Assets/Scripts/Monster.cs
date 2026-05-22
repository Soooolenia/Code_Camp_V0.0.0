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

    [Header("Monster Audio")]
    [SerializeField] private AudioSource monsterDeath;
    [SerializeField] private AudioSource monsterHurt;
    [SerializeField] private AudioSource monsterRevive;
    [SerializeField] private AudioSource monsterGeneral;

    [Header("Machine Audio")]
    [SerializeField] private AudioSource killSpike;
    [SerializeField] private AudioSource killWeak;
    [SerializeField] private AudioSource revive;

    [SerializeField] private Animator animator;

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

            monsterDeath.Play();
            killSpike.Play();
            monsterGeneral.Stop();

            animator.SetTrigger("Kill");

            Debug.Log("Monster has been killed!");
            machine.DamageCounter();
            energyManager.IncreaseEnergy(1.75f);

        }

        else
        {
            Debug.Log($"Monster current health: {MonsterHealth}");
            killWeak.Play();
            animator.SetTrigger("Damaged");
            monsterHurt.Play();
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

        //monsterAlive.gameObject.SetActive(true);
        //monsterDead.gameObject.SetActive(false);

        animator.SetTrigger("Revive");

        revive.Play();
        monsterRevive.Play();
        monsterGeneral.Play();

        MonsterHealth = 3;
        Debug.Log("Monster has been revived!");

        machine.DamageCounter();

        // TODO: Add revival animation or effects here
    }
}
