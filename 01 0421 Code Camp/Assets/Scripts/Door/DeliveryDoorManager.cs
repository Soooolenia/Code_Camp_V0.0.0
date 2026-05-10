using System;
using UnityEngine;

public class DeliveryDoorManager : MonoBehaviour
{
    private bool DoorIsBroken = false;

    public bool IsBroken()
    {
        return DoorIsBroken;
    }

    // ADDED: A way to update the state from your other scripts
    public void SetBrokenState(bool state)
    {
        DoorIsBroken = state;
    }
}
