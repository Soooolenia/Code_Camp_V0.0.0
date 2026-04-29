using UnityEngine;
using UnityEngine.Events;

public class Part : MonoBehaviour
{
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject damaged;
    [SerializeField] private GameObject broken;

    [SerializeField] private Machine machine;

    [SerializeField] private InteractableKill interactableKill;

    public bool IsDamaged = false;
    public bool IsBroken = false;

    [SerializeField] private int damageLevel = 0;

    public UnityEvent OnDamaged;

    public void DamagePart()
    {
        if (IsBroken) { return; }

        if (IsDamaged == false)
        {
            Debug.Log($"Part {gameObject.name} is damaged!");
            good.SetActive(false);
            damaged.SetActive(true);

            IsDamaged = true;

            //damage the kill
            interactableKill.KillDamage -= 1;
            Debug.Log($"Part {gameObject.name} reduced kill damage by 1");
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
            damageLevel += 1;
            Debug.Log($"{gameObject.name} damage level: {damageLevel}");

            if (damageLevel >= 2)
            {
                good.SetActive(false);
                damaged.SetActive(false);
                broken.SetActive(true);
                Debug.Log($"Part {gameObject.name} is broken!");
                IsBroken = true;

                machine.MachineIsWorking = false;
            }
        }
        else
        {
            damageLevel = 0;
            machine.MachineIsWorking = true;
        }
    }
}
