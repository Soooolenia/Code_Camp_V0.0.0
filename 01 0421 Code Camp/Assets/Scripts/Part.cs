using UnityEngine;
using UnityEngine.Events;

public class Part : MonoBehaviour
{
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject damaged;
    [SerializeField] private GameObject broken;

    [SerializeField] private Machine machine;

    private bool isDamaged = false;
    public bool isBroken = false;

    [SerializeField] private int damageLevel = 0;

    public UnityEvent OnDamaged;

    public void DamagePart()
    {
        if (isBroken) { return; }

        if (isDamaged == false)
        {
            Debug.Log($"Part {gameObject.name} is damaged!");
            good.SetActive(false);
            damaged.SetActive(true);

            isDamaged = true;
            //startDamagedCounter();
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

        if(isBroken) { return; }

        if (isDamaged)
        {
            damageLevel += 1;
            Debug.Log($"{gameObject.name} damage level: {damageLevel}");

            if (damageLevel >= 2)
            {
                good.SetActive(false);
                damaged.SetActive(false);
                broken.SetActive(true);
                Debug.Log($"Part {gameObject.name} is broken!");
                isBroken = true;

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
