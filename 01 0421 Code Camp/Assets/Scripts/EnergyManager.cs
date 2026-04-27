using System;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] public float CurrentEnergy = 1f;
    [SerializeField] private float targetEnergy = 5f;

    internal void EnergyCheck()
    {
        if (CurrentEnergy >= targetEnergy)
        {
            Debug.Log("Target energy reached!");
        }
    }
}
