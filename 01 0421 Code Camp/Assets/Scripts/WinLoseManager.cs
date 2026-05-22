using System.Threading.Tasks;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private AudioSource monsterOut;
    [SerializeField] private Animator PPDark;

    [SerializeField] private GameObject deathByEscape;
    [SerializeField] private GameObject deathBySwing;
    [SerializeField] private GameObject win;

    [SerializeField] private AudioSource fullyCharged;
    public async void Win()
    {
        fullyCharged.Play();
        await Task.Delay(4755);

        Cursor.lockState = false ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = true;

        win.SetActive(true);
        fullyCharged.Play();
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
        Cursor.lockState = false ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = true;
    }
    public void DeathByMonsterSwing()
    {
        PPDark.SetTrigger("Darken");

        deathBySwing.SetActive(true);

        Cursor.lockState = false ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = true;
    }


}
