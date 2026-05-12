using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {

    }

    public virtual void InteractHold()
    {

    }

    public virtual void InteractStop()
    {

    }
    public virtual void HoverStay()
    {

    }
    public virtual void HoverExit()
    {

    }

    public virtual bool CanInteract()
    {
        return true;
    }
}
