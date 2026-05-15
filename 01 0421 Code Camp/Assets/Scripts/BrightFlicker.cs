using Unity.VisualScripting;
using UnityEngine;

public class BrightFlicker : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Brighten()
    {
        animator.SetTrigger("Brighten");
    }
    public void BrightenSmall()
    {
        animator.SetTrigger("BrightenSmall");
    }
    public void Darken()
    {
        animator.SetTrigger("Darken");
    }
    public void DarkenSmall()
    {
        animator.SetTrigger("DarkenSmall");
    }
}
