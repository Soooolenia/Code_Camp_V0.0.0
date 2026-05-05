using System;
using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private int energyThreshold;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (energyManager.CurrentEnergy >= energyThreshold)
        {
            lightBulbOn();
        }
        else if (energyManager.CurrentEnergy <= energyThreshold - 1)
        {
            lightBulbOff();
        }
        else
        {
            lightBulbFlickering();
        }
    }
    private void lightBulbOn()
    {
        animator.SetTrigger("On");
    }
    private void lightBulbOff()
    {
        animator.SetTrigger("Off");
    }
    private void lightBulbFlickering()
    {
        animator.SetTrigger("Flicker");
    }
}
