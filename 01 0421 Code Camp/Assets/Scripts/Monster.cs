using UnityEngine;

public class Monster : MonoBehaviour
{
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

        // TODO: Add revival animation or effects here
    }
}
