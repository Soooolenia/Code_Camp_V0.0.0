using System;
using UnityEngine;

public class DeliveryIndicator : MonoBehaviour
{
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;
    [SerializeField] private Animator animator;

    public void Off()
    {
        off.SetActive(true);
        on.SetActive(false);
    }

    public void On()
    {
        off.SetActive(false);
        on.SetActive(true);
    }

    public void InProgress()
    {
        off.SetActive(false);
        on.SetActive(true);
        animator.Play("Delivery_In_Progress");
    }

    public void InProgressStop()
    {
        animator.Play("Idle");
    }
}
