using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] public float CurrentEnergy = 1f;
    [SerializeField] public float TargetEnergy = 5f;

    private void EnergyCheck()
    {
        if (CurrentEnergy >= TargetEnergy)
        {
            Debug.Log("Target energy reached!");
        }
    }

    public void IncreaseEnergy()
    {
        Debug.Log("Energy increased by 1");
        CurrentEnergy += 1f;

        //Run Energy Level Check
        EnergyCheck();
    }

    public void DecreaseEnergy()
    {
        Debug.Log("Energy decreased by 0.2");
        CurrentEnergy -= 0.2f;
        //Run Energy Level Check
        EnergyCheck();
    }
}
