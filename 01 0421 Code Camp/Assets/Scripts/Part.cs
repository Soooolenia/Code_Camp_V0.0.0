using UnityEngine;
using UnityEngine.Events;

public class Part : MonoBehaviour
{
    [SerializeField] public GameObject Good;
    [SerializeField] private GameObject damaged;
    [SerializeField] private GameObject broken;

    [SerializeField] private InteractableKill interactableKill;

    [SerializeField] private ParticleSystem smallExplosion;
    [SerializeField] private ParticleSystem machineSmoke;

    public bool IsDamaged = false;
    public bool IsBroken = false;

    public int PartDamage
    {
        get
        {
            if (IsDamaged)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    [SerializeField] public int DamageLevel = 0;

    public UnityEvent OnDamaged;

    public void DamagePart()
    {
        if (IsBroken) { return; }

        if (IsDamaged == false)
        {
            //Damage part
            Debug.Log($"Part {gameObject.name} is damaged!");
            Good.SetActive(false);
            damaged.SetActive(true);
            IsDamaged = true;
            //PartDamage = 0;

            //damage the kill
            //interactableKill.KillDamage -= 1;
            //Debug.Log($"Part {gameObject.name} reduced kill damage by 1");
        }
        else
        {
            Debug.Log($"Part {gameObject.name} is already damaged!");
        }

        OnDamaged.Invoke();
    }

    public void DamageCounter()
    {
        //If part is broken, add one to damage counter
        //If part is not broken, set damage counter back to 0

        if(IsBroken) { return; }

        if (IsDamaged)
        {
            DamageLevel += 1;
            Debug.Log($"{gameObject.name} damage level: {DamageLevel}");

            if (DamageLevel >= 2)
            {
                Good.SetActive(false);
                damaged.SetActive(false);
                broken.SetActive(true);
                Debug.Log($"Part {gameObject.name} is broken!");
                smallExplosion.Play();

                IsBroken = true;

                // because part is broken, it's no longer damaged
                IsDamaged = false;
                //PartDamage = 1;
            }
        }
        else
        {
            DamageLevel = 0;
            //machine.MachineIsWorking = true;
            //machineSmoke.Stop();
        }
    }

    public void BreakPartFr()
    {
        Good.SetActive(false);
        damaged.SetActive(false);
        broken.SetActive(true);
        Debug.Log($"Part {gameObject.name} is broken!");
        smallExplosion.Play();

        IsBroken = true;

        IsDamaged = false;
    }
}
