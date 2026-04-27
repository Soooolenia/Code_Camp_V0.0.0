using UnityEngine;

public class InteractableRevive : Interactable
{
    [SerializeField] private Monster monster;

    public override void Interact()
    {
        //Check if the monster is alive
        //If alive, revive
        //If not, debug log "Monster is already alive!"

        if (monster.IsAlive == true)
        {
            Debug.Log("Monster is already alive!");
            return;
        }

        Debug.Log("Monster has been revived!");
        monster.Revive();
    }
}
