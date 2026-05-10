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

    [SerializeField] private float cooldown = 1f;
    public int KillDamage
    {
        get
        {
            if (partA == null || partB == null || partC == null) {return 0;}

            return partA.PartDamage + partB.PartDamage + partC.PartDamage;
        }
    }

    public override void Interact()
    {
        if (cooldown < 1f) { return;}

        if (machine.IsBroken())
        {
            Debug.Log("The machine is broken!");
            return;
        }

        //Check if the monster is alive
        if (monster.IsAlive == false)
        {
            Debug.Log("Monster is already dead!");
            return;
        }
        //Kill the monster
        monster.Kill();
        animator.SetTrigger("Kill");

        cooldown = 0f;

        energyManager.DecreaseEnergy();

        //Decide if parts break or not
        if (Random.value < 0.5f)
        {
            machine.BreakParts();
        }
    }
    private void Update()
    {
        cooldown += 0.1f * Time.deltaTime;
        cooldown = Mathf.Clamp(cooldown, 0f, 1f);
    }
}
