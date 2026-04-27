using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private InteractablePartA partA;
    [SerializeField] private InteractablePartB partB;
    [SerializeField] private InteractablePartC partC;
    public void BreakParts()
    {
        //Decide which one to break
        //Call break function in part

        if (Random.value < 0.33f)
        {
            partA.DamagePartA();
        }
        else if (Random.value < 0.66f)
        {
            partB.DamagePartB();
        }
        else
        {
            partC.DamagePartC();
        }
    }
}
