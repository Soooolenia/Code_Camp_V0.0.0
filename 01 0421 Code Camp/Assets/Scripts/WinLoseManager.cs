using System.Threading.Tasks;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private AudioSource monsterOut;
    [SerializeField] private Animator PPDark;

    [SerializeField] private GameObject deathByEscape;
    [SerializeField] private GameObject deathBySwing;
    [SerializeField] private GameObject win;
    public void Win()
    {
        win.SetActive(true);
    }
    public void Lose()
    {
        PPDark.SetTrigger("Darken");

        if (!monsterOut.isPlaying)
        {
            monsterOut.Play();
        }
    }
    public async void DeathByEscapedMonster()
    {
        PPDark.SetTrigger("Darken");

        if (!monsterOut.isPlaying)
        {
            monsterOut.Play();
        }

        await Task.Delay(4000);

        deathByEscape.SetActive(true);
    }
    public async void DeathByMonsterSwing()
    {
        PPDark.SetTrigger("Darken");

        deathBySwing.SetActive(true);
    }
}
