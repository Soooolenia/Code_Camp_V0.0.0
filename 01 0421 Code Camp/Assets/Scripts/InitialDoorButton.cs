using UnityEngine;

public class InitialDoorButton : Interactable
{
    [SerializeField] private Animator animator;
    public override void Interact()
    {
        //Debug.Log("Door button pressed!");
        animator.SetTrigger("Open");
    }
}
