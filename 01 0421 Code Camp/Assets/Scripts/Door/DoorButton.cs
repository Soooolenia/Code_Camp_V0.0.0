using UnityEngine;

public class DoorButton : Interactable
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator audioAnimator;
    public override void Interact()
    {
        //Debug.Log("Door button pressed!");
        animator.SetTrigger("Open");
        audioAnimator.SetTrigger("Open");
        GetComponentInChildren<AudioSource>().Play();
    }
}
