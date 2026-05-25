using UnityEngine;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Animator introLoop;
    [SerializeField] private Animator darkHearts;
    [SerializeField] private Animator dangerLoop;

    [SerializeField] private AudioSource dangerSting;

    //private bool isDangerActive = false;

    private bool areContraintsBroken = false;
    public bool AreContraintsBroken
    {
        get => areContraintsBroken;
        set
        {
            if (areContraintsBroken == value) { return; }
            areContraintsBroken = value;
            Check();
        }
    }

    private bool isEnergyLow = false;
    public bool IsEnergyLow
    {
        get => isEnergyLow;
        set
        {
            if (isEnergyLow == value) { return; }
            isEnergyLow = value;
            Check();
        }
    }

    private MusicState state;
    private MusicState State
    {
        get => state;
        set
        {
            if (state == value) { return; }
            Debug.Log(value);
            state = value;
            darkHearts.SetTrigger(state == MusicState.Normal ? "On" : "Off");
            dangerLoop.SetTrigger(state == MusicState.Danger ? "On" : "Off");

            if (value == MusicState.Danger)
            {
                dangerSting.Play();
            }
        }
    }

    private void Check()
    {
        if (AreContraintsBroken || IsEnergyLow)
        {
            if (State == MusicState.Danger) { return; }
            State = MusicState.Danger;
            dangerLoop.SetTrigger("On");
            darkHearts.SetTrigger("Off");
            dangerSting.Play();
        }
        else
        {
            if (State == MusicState.Normal) { return; }
            State = MusicState.Normal;
            dangerLoop.SetTrigger("Off");
            darkHearts.SetTrigger("On");
        }
    }

    public void IntroLoopCut()
    {
        introLoop.SetTrigger("End");
    }
    public void InitialStart()
    {
        darkHearts.SetTrigger("On");
    }
}

public enum MusicState
{
    Normal,
    Danger
}
