using UnityEngine;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Animator introLoop;
    [SerializeField] private Animator darkHearts;
    [SerializeField] private Animator dangerLoop;

    [SerializeField] private AudioSource dangerSting;
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
        darkHearts.SetTrigger("On");
        dangerLoop.SetTrigger("Off");
    }

    public void StartDangerLoop()
    {
        dangerLoop.SetTrigger("On");
        darkHearts.SetTrigger("Off");
        dangerSting.Play();
    }
}
