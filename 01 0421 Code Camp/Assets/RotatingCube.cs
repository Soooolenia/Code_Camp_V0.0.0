using UnityEngine;
using UnityEngine.InputSystem;

public class RotatingCube : MonoBehaviour
{
   
    [SerializeField] float targetNumber = 10f;
    float currentNumber = 0f;
    public bool IsTargetReached => currentNumber >= targetNumber;

    public void Increment(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        currentNumber += 1f;
        if (currentNumber != targetNumber) return;
       
        Debug.Log($"Target number reached for {gameObject.name}!");
        FindAnyObjectByType<CubePuzzleManager>()?.CheckCubes();
    }
}
