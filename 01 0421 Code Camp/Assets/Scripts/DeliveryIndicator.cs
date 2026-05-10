using System;
using UnityEngine;

public class DeliveryIndicator : MonoBehaviour
{
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;

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
}
