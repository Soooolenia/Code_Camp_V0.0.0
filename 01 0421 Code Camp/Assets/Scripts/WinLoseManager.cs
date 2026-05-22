using UnityEngine;
using System.Threading.Tasks;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private AudioSource monsterOut;
    [SerializeField] private Animator PPDark;

    [SerializeField] private GameObject deathByMonsterEscape;
    [SerializeField] private GameObject deathBySwing;
    [SerializeField] private GameObject win;
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

    public async void DeathByMonsterEscape()
    {
        PPDark.SetTrigger("Darken");

        if (!monsterOut.isPlaying)
        {
            monsterOut.Play();
        }

        await Task.Delay(4000);

        deathByMonsterEscape.SetActive(true);

        Cursor.lockState = false ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
