using System;
using UnityEngine;

public class ButtonIndicator : MonoBehaviour
{
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;
    public void On()
    {
        on.SetActive(true);
        off.SetActive(false);
    }
    public void Off()
    {
        on.SetActive(false);
        off.SetActive(true);
    }
}
