using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private AudioSource monsterOut;
    [SerializeField] private Animator PPDark;
    public void Win()
    {

    }
    public void Lose()
    {
        PPDark.SetTrigger("Darken");

        if (!monsterOut.isPlaying)
        {
            monsterOut.Play();
        }
    }
}
