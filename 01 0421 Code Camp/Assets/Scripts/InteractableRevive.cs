using UnityEngine;

public class InteractableRevive : Interactable
{
    public override void Interact()

    {
        //Check if the monster is alive
        //If alive, revive
        //If not, debug log "Monster is already alive!"

        if (FindAnyObjectByType<InteractableKill>().IsMonsterAlive == true)
        {
            Debug.Log("Monster is already alive!");
            return;
        }
        FindAnyObjectByType<InteractableKill>().IsMonsterAlive = true;
        Debug.Log("Monster has been revived!");

    }
}
