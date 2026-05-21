using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private AudioSource monsterOut;
    public void Win()
    {

    }
    public void Lose()
    {
        monsterOut.Play();
    }
}
