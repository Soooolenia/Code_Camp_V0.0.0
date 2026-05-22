using System.Collections;
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
    [SerializeField] private AudioSource monsterFinalAudio;
    [SerializeField] private AudioSource monsterFinalMusic;

    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject cam2;
    [SerializeField] private GameObject cam3;

    [SerializeField] private Animator monster;

    private bool isGameOver = false;
    public void Win()
    {
        fullyCharged.Play();
        if (isGameOver) { return; }
        isGameOver = true;
        
        //await Task.Delay(4755);
        
        StartCoroutine(WinSequence());
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

    IEnumerator WinSequence()
    {
        cam1.SetActive(true);
        monster.SetTrigger("End");
        monsterFinalAudio.Play();
        monsterFinalMusic.Play();
        yield return new WaitForSeconds(15f);
        cam2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        cam3.SetActive(true);
        yield return new WaitForSeconds(3);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        win.SetActive(true);
    }
}
