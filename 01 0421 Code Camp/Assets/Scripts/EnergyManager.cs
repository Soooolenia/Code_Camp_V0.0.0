using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] private float currentEnergy = 1f;
    [SerializeField] private float targetEnergy = 5f;

    private void EnergyCheck()
    {
        if (currentEnergy >= targetEnergy)
        {
            Debug.Log("Target energy reached!");
        }
    }

    public void IncreaseEnergy()
    {
        Debug.Log("Energy increased by 1");
        currentEnergy += 1f;

        //Run Energy Level Check
        EnergyCheck();
    }
}
