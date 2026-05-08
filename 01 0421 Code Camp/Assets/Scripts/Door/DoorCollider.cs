using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Close");
        gameObject.SetActive(false);
    }
}
