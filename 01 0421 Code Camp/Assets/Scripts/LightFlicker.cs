using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] private EnergyManager energyManager;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Drop()
    {
        animator.SetTrigger("Drop");
    }
    public void Rise()
    {
        animator.SetTrigger("Rise");
    }
}
