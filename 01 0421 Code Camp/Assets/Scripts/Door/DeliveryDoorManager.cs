using System;
using UnityEngine;

public class DeliveryDoorManager : MonoBehaviour
{
    private bool DoorIsBroken = false;
    public bool IsBroken()
    {
        return DoorIsBroken;
    }
    public void SetBrokenState(bool state)
    {
        DoorIsBroken = state;
    }
}
