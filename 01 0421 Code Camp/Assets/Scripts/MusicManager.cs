using UnityEngine;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Animator introLoop;
    [SerializeField] private Animator darkHearts;
    [SerializeField] private Animator dangerLoop;

    [SerializeField] private AudioSource dangerSting;

    private bool isDangerActive = false;
    public void IntroLoopCut()
    {
        introLoop.SetTrigger("End");
    }
    public void InitialStart()
    {
        darkHearts.SetTrigger("On");
    }
    public void StartDarkHearts()
    {
        if (isDangerActive)
        {
            darkHearts.SetTrigger("On");
            dangerLoop.SetTrigger("Off");
            isDangerActive = false;
        }
    }

    public void StartDangerLoop()
    {
        if (!isDangerActive)
        {
            dangerLoop.SetTrigger("On");
            darkHearts.SetTrigger("Off");
            dangerSting.Play();
            isDangerActive = true;
        }
    }
}
