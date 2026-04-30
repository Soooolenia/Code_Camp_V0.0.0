using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool GoodPartInHand = false;
    public bool BrokenPartInHand = false;

    [SerializeField] private GameObject badPartShowing;
    [SerializeField] private GameObject goodPartShowing;

    private SlotA slotToRepair;

    public void ShowBadObjectInHand()
    {
        badPartShowing.SetActive(true);
    }
    public void ShowGoodObjectInHand()
    {
        goodPartShowing.SetActive(true);
    }
    public void HideBadObjectInHand()
    {
        badPartShowing.SetActive(false);
    }
    public void HideGoodObjectInHand()
    {
        goodPartShowing.SetActive(false);
    }

    public void SetTargetSlotForReplacement(SlotA slot)
    {
        slotToRepair = slot;
    }

    public SlotA GetSlotToRepair()
    {
        SlotA slotToReturn = slotToRepair;
        slotToRepair = null;
        return slotToReturn;
    }
}
