using UnityEngine;

public class MonsterReach : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You Died!");
    }
}
