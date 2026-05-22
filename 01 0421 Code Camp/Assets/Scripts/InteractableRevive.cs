using Unity.VisualScripting;
using UnityEngine;

public class InteractableRevive : Interactable
{
    [SerializeField] private Monster monster;
    [SerializeField] private Machine machine;

    [SerializeField] private Animator animatorR;
    [SerializeField] private Animator animatorL;

    [SerializeField] private float cooldown = 1f;

    [SerializeField] private EnergyManager energyManager;

    [SerializeField] private ButtonIndicator indicator;

    [SerializeField] private AudioSource buttonClick;
    [SerializeField] private AudioSource coolDownReady;

    [SerializeField] private MusicManager musicManager;

    private bool introLoopEnded = false;

    private bool isReadySoundPlayed = false;

    private bool isGameStarted = false;

    public override void Interact()
    {

        if (cooldown < 1f) { return; }

        //Check if the monster is alive
        //If alive, revive
        //If not, debug log "Monster is already alive!"

        if (machine.IsBroken())
        {
            //Debug.Log("The machine is broken!");
            return;
        }

        if (monster.IsAlive == true)
        {
            //Debug.Log("Monster is already alive!");
            return;
        }

        monster.Revive();
        animatorR.SetTrigger("Revive");
        animatorL.SetTrigger("Revive");
        cooldown = 0f;

        buttonClick.Play();

        energyManager.DecreaseEnergy(0.25f);

        //Decide if parts break or not
        if (Random.value < 0.5f)
        {
            machine.BreakParts();
        }


        if (introLoopEnded == false)
        {
            musicManager.IntroLoopCut();
            musicManager.InitialStart();
            introLoopEnded = true;
        }

        energyManager.startGame();
    }
    private void Update()
    {
        cooldown += 0.2f * Time.deltaTime;
        cooldown = Mathf.Clamp(cooldown, 0f, 1f);


        if (cooldown >= 1f)
        {
            indicator.On();

            // Only play if we haven't played it yet for this cycle
            if (!isReadySoundPlayed)
            {
                coolDownReady.Play();
                isReadySoundPlayed = true;
            }
        }
        else
        {
            indicator.Off();

            // IMPORTANT: Reset the flag when the cooldown is NOT full
            // This ensures it can play again the next time it finishes
            isReadySoundPlayed = false;
        }
    }
}
