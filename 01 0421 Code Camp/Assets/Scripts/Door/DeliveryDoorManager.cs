using System;
using UnityEngine;

public class DeliveryDoorManager : MonoBehaviour
{
    [SerializeField] private bool DoorIsBroken = false;
    public bool IsBroken()
    {
        return DoorIsBroken;
    }
    public void SetBrokenState(bool state)
    {
        DoorIsBroken = state;
    }
}
