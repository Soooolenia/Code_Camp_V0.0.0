using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Machine machine;

    private bool isAlive = true;

    public bool IsAlive => isAlive;

    public void Kill()
    {
        if (!isAlive)
        {
            Debug.Log("Monster is already dead!");
            return;
        }
        isAlive = false;
        Debug.Log("Monster has been killed!");

        machine.DamageCounter();

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
        Debug.Log("Monster has been revived!");

        machine.DamageCounter();

        // TODO: Add revival animation or effects here
    }
}
