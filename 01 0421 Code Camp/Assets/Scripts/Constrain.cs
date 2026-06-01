using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;

public class Constrain : Interactable
{
    [SerializeField] private GameObject goodConstrain;
    [SerializeField] private GameObject midConstrain;
    [SerializeField] private GameObject badConstrain;

    [SerializeField] private GameObject monsterCollider;

    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private ConstrainManager constrainManager;

    [SerializeField] private ConstraintState state;

    // Property
    public ConstraintState State
    {
        get => state;
        set
        {
            if (state == value) { return; }
            Debug.Log(value);
            state = value;
            monsterCollider.SetActive(value == ConstraintState.Broken);
            badConstrain.SetActive(value == ConstraintState.Broken);
            midConstrain.SetActive(value == ConstraintState.Damaged);
            goodConstrain.SetActive(value == ConstraintState.Normal);

            constrainManager.Check();

            if (state != ConstraintState.Normal)
            {
                breakDown.Play();
            }
        }
    }


    [SerializeField] public float damage = 0f;
    [SerializeField] private float damageSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private char side;

    [SerializeField] private Animator UIAnimation;
    [SerializeField] private GameObject repairUI;

    [SerializeField] private AudioSource repairSound;
    [SerializeField] private AudioSource repairComplete;
    [SerializeField] private AudioSource breakDown;

    //[SerializeField] private MusicManager musicManager;

    /*private bool hasTriggeredDamagedEffects = false;
    private bool hasTriggeredBrokenEffects = false;*/

    private void Start()
    {
        State = ConstraintState.Normal;
        monsterCollider.SetActive(false);
        badConstrain.SetActive(false);
        midConstrain.SetActive(false);
        goodConstrain.SetActive(true);
    }

    void Update()
    {
        if (monster.isAlive)
        {
            damage += damageSpeed * Time.deltaTime;

            if (State == ConstraintState.Damaged && damage >= 1f)
            {
                State = ConstraintState.Broken;
                /*monsterCollider.SetActive(true);
                badConstrain.SetActive(true);
                midConstrain.SetActive(false);
                goodConstrain.SetActive(false);
                constrainManager.Check();
                animator.SetTrigger($"Break{side}");

                
                if (!hasTriggeredBrokenEffects)
                {
                    breakDown.Play();
                    
                    //musicManager.StartDangerLoop();
                    Debug.Log("Danger Loop Played");
                    hasTriggeredBrokenEffects = true;
                }*/
            }
            else if (State == ConstraintState.Normal && damage >= 0.5f)
            {
                State = ConstraintState.Damaged;
                /*monsterCollider.SetActive(false);
                badConstrain.SetActive(false);
                midConstrain.SetActive(true);
                goodConstrain.SetActive(false);
                constrainManager.Check();

                if (!hasTriggeredDamagedEffects)
                {
                    breakDown.Play();
                    hasTriggeredDamagedEffects = true;
                }*/
            }

        }
    }
    public async override void Interact()
    {
        Debug.Log("Interacted with Constrain");
        damage = 0f;
        energyManager.DecreaseEnergy(0.15f);
        State = ConstraintState.Normal;
        Debug.Log("Constrain Repaired" + State);
        /*monsterCollider.SetActive(false);
        badConstrain.SetActive(false);
        midConstrain.SetActive(false);
        goodConstrain.SetActive(true);
        Debug.Log("Constrain Repaired");

        hasTriggeredDamagedEffects = false;
        hasTriggeredBrokenEffects = false;
        //musicManager.StartDarkHearts();*/

        repairUI.SetActive(true);
        UIAnimation.Play("Repair");
        repairSound.Play();
        await Task.Delay(1666);
        repairUI.SetActive(false);
        repairComplete.Play();
    }
}

