using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings Variables")]
    [SerializeField] private List<GameObject> goodParts;
    [SerializeField] private List<GameObject> brokenParts;

    [SerializeField] private List<GameObject> goodPartsInMachine;

    [Header("In-game Variables")]
    [SerializeField] private int currentGoodPartIndex = -1;
    [SerializeField] private int currentBrokenPartIndex = -1;

    [SerializeField] private int currentGoodPartInMachineIndex = -1;

    private Slot slotToRepair;

    public void ShowBadObjectInHand(int partIndex)
    {
        // Show the new bad object
        brokenParts[partIndex].SetActive(true);
        currentBrokenPartIndex = partIndex;
    }

    public void ShowGoodObjectInHand(int partIndex)
    {
        goodParts[partIndex].SetActive(true);
        currentGoodPartIndex = partIndex;
    }

    public void HideBadObjectInHand()
    {
        brokenParts[currentBrokenPartIndex].SetActive(false);
        currentBrokenPartIndex = -1;
    }

    public void HideGoodObjectInHand()
    {
        goodParts[currentGoodPartIndex].SetActive(false);
        currentGoodPartIndex = -1;
    }
    public void ShowGoodObjectInMachine(int partIndex)
    {
        goodPartsInMachine[partIndex].SetActive(true);
        currentGoodPartInMachineIndex = partIndex;
    }
    public void HideGoodObjectInMachine()
    {
        goodPartsInMachine[currentGoodPartInMachineIndex].SetActive(false);
        currentGoodPartInMachineIndex = -1;
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

    public Slot PeekSlotToRepair()
    {
        return slotToRepair;
    }
}
