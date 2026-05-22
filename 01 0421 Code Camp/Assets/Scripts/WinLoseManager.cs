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
    [SerializeField] private AudioSource energyDepleted;

    private bool isGameOver = false;
    public async void Win()
    {
        if (isGameOver) { return; }
        isGameOver = true;

        fullyCharged.Play();
        await Task.Delay(4755);

        Cursor.lockState = CursorLockMode.None;
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
        if (isGameOver) { return; }
        isGameOver = true;

        energyDepleted.Play();
        Debug.Log("Death By Escaped Monster");

        PPDark.SetTrigger("Darken");
        Debug.Log("PP Dark Played");

        if (!monsterOut.isPlaying)
        {
            monsterOut.Play();
        }

        await Task.Delay(4000);

        deathByEscape.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void DeathByMonsterSwing()
    {
        if (isGameOver) { return; }
        isGameOver = true;
        Debug.Log("DeathByMonsterSwing");

        PPDark.SetTrigger("Darken");

        deathBySwing.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
