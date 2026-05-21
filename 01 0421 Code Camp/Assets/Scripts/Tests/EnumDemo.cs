using UnityEngine;

public class EnumDemo : MonoBehaviour
{
    public PartState MyPartState = PartState.Normal;

    public void Interact()
    {
        if (Random.value < 0.5f)
        {
            if (Random.value < 0.2f)
            {
                MyPartState = PartState.Broken;
            }
            else
            {
                MyPartState = PartState.Damaged;
            }
        }
    }
}

public enum PartState
{
    Normal,
    Damaged,
    Broken,
    Posessed,
}
