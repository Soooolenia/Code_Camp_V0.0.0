using UnityEngine;
using System.Threading.Tasks;

public class Constrain : Interactable
{
    [SerializeField] private GameObject goodConstrain;
    [SerializeField] private GameObject midConstrain;
    [SerializeField] private GameObject badConstrain;

    [SerializeField] private GameObject monsterCollider;

    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private ConstrainManager constrainManager;

    [SerializeField] public ConstraintState State = ConstraintState.Normal;
    [SerializeField] public float damage = 0f;
    [SerializeField] private float damageSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private char side;

    [SerializeField] private Animator UIAnimation;
    [SerializeField] private GameObject repairUI;

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
            //if (damage > 1f || damage  < 0f) {return;}

            damage += damageSpeed * Time.deltaTime;

            if (State == ConstraintState.Damaged && damage >= 1f)
            {
                State = ConstraintState.Broken;
                monsterCollider.SetActive(true);
                badConstrain.SetActive(true);
                midConstrain.SetActive(false);
                goodConstrain.SetActive(false);
                constrainManager.Check();
                animator.SetTrigger($"Break{side}");
            }
            else if (State == ConstraintState.Normal && damage >= 0.5f)
            {
                State = ConstraintState.Damaged;
                monsterCollider.SetActive(false);
                badConstrain.SetActive(false);
                midConstrain.SetActive(true);
                goodConstrain.SetActive(false);
                constrainManager.Check();
                animator.SetTrigger("Struggle");
            }
        }
    }
    public async override void Interact()
    {
        damage = 0f;
        energyManager.DecreaseEnergy(0.15f);
        State = ConstraintState.Normal;
        monsterCollider.SetActive(false);
        badConstrain.SetActive(false);
        midConstrain.SetActive(false);
        goodConstrain.SetActive(true);
        Debug.Log("Constrain Repaired");

        repairUI.SetActive(true);
        UIAnimation.Play("Repair");
        await Task.Delay(667);
        repairUI.SetActive(false);
    }
}

