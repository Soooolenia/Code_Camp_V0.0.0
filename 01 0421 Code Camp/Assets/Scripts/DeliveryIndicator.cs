using System;
using UnityEngine;

public class DeliveryIndicator : MonoBehaviour
{
    //[SerializeField] private GameObject on;
    //[SerializeField] private GameObject off;
    [SerializeField] private Animator animator;

    public void Off()
    {
        //off.SetActive(true);
        //on.SetActive(false);
        animator.SetTrigger("Off");
    }

    public void On()
    {
        //off.SetActive(false);
        //on.SetActive(true);
        animator.SetTrigger("On");
    }

    public void InProgress()
    {
        //off.SetActive(false);
        //on.SetActive(true);
        animator.SetTrigger("Flicker");
    }

    public void InProgressStop()
    {
        animator.SetTrigger("On");
    }
}
