using UnityEngine;

public class InitialDoorButton : Interactable
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource doorOpen;
    public override void Interact()
    {
        //Debug.Log("Door button pressed!");
        animator.SetTrigger("Open");
        buttonSound.Play();
        doorOpen.Play();
    }
}
