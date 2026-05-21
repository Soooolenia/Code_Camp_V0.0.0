using UnityEngine;

public class MonsterReach : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private char side;

    [SerializeField] private AudioSource monsterSwing;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You Died!");
        animator.SetTrigger($"Swipe{side}");

        monsterSwing.Play();
    }
}
