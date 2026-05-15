using UnityEngine;

public class InteractableKill : Interactable
{
    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private Machine machine;

    [SerializeField] private Animator animator;

    [SerializeField] private Part partA;
    [SerializeField] private Part partB;
    [SerializeField] private Part partC;

    [SerializeField] private ButtonIndicator indicator;

    [SerializeField] private float cooldown;

    [SerializeField] private AudioSource buttonClick;
    [SerializeField] private AudioSource coolDownReady;

    private bool isReadySoundPlayed = false;
    public int KillDamage
    {
        get
        {
            if (partA == null || partB == null || partC == null) { return 0; }

            return partA.PartDamage + partB.PartDamage + partC.PartDamage;
        }
    }

    public override void Interact()
    {
        if (cooldown < 1f) { return; }

        if (machine.IsBroken())
        {
            //Debug.Log("The machine is broken!");
            return;
        }

        //Check if the monster is alive
        if (monster.IsAlive == false)
        {
            //Debug.Log("Monster is already dead!");
            return;
        }
        //Kill the monster
        monster.Kill();
        animator.SetTrigger("Kill");

        buttonClick.Play();

        cooldown = 0f;

        energyManager.DecreaseEnergy(0.25f);

        //Decide if parts break or not
        if (Random.value < 0.3f)
        {
            machine.BreakParts();
        }
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
