using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool GoodPartInHand = false;
    public bool BrokenPartInHand = false;

    [SerializeField] private GameObject badPartShowing;
    [SerializeField] private GameObject goodPartShowing;

    private Slot slotToRepair;

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

    public void SetTargetSlotForReplacement(Slot slot)
    {
        slotToRepair = slot;
    }

    public Slot GetSlotToRepair()
    {
        Slot slotToReturn = slotToRepair;
        slotToRepair = null;
        return slotToReturn;
    }
}
