using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {

    }

    public virtual bool CanInteract()
    {
        return true;
    }
}
