using UnityEngine;

public class SetButtonAnimatorOnEnabled : MonoBehaviour
{
    private Animator animator;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Normal");

        animator.ResetTrigger("Highlighted");
        animator.ResetTrigger("Pressed");
        animator.ResetTrigger("Selected");
        animator.ResetTrigger("Disabled");
    }
}
