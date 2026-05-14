using UnityEngine;

public class Constrain : Interactable
{
    [SerializeField] private GameObject goodConstrain;
    [SerializeField] private GameObject midConstrain;
    [SerializeField] private GameObject badConstrain;

    [SerializeField] private GameObject monsterCollider;

    [SerializeField] private Monster monster;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private ConstrainManager constrainManager;

    [SerializeField] public bool IsConstrainBroken = false;
    [SerializeField] public float damage = 0f;
    [SerializeField] private float damageSpeed;

    void Update()
    {
        if (monster.isAlive)
        {
            if (damage > 1f || damage  < 0f) { return; }

            damage += damageSpeed * Time.deltaTime;

            if (damage >= 1)
            {
                IsConstrainBroken = true;
                monsterCollider.SetActive(true);
                badConstrain.SetActive(true);
                goodConstrain.SetActive(false);
                constrainManager.Check();
            }

            if (damage >= 0.5)
            {
                IsConstrainBroken = false;
                monsterCollider.SetActive(false);
                badConstrain.SetActive(false);
                midConstrain.SetActive(true);
                goodConstrain.SetActive(false);
                constrainManager.Check();
            }

            else
            {
                IsConstrainBroken = false;
                monsterCollider.SetActive(false);
                badConstrain.SetActive(false);
                midConstrain.SetActive(false);
                goodConstrain.SetActive(true);
                constrainManager.Check();
            }
        }
    }
    public override void Interact()
    {
        damage = 0f;
        energyManager.DecreaseEnergy(0.15f);
        IsConstrainBroken = false;
        monsterCollider.SetActive(false);
        badConstrain.SetActive(false);
        goodConstrain.SetActive(true);
        Debug.Log("Constrain Repaired");
    }
}

