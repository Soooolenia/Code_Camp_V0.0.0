using UnityEngine;
using UnityEngine.UI;

public class UIClickIndicator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.Play("Idle", 0);
    }
}
