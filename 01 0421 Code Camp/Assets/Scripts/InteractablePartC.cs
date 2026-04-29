using System;
using UnityEngine;

public class InteractablePartC : MonoBehaviour
{
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject damaged;
    [SerializeField] private GameObject broken;

    private bool isDamaged = false;
    private void Awake()
    {
        good.SetActive(true);
        damaged.SetActive(false);
        broken.SetActive(false);
    }
    public void DamagePartC()
    {
        if (isDamaged == false)
        {
            Debug.Log("Part B broke!");
            good.SetActive(false);
            damaged.SetActive(true);

            isDamaged = true;
        }
        else
        {
            Debug.Log("Part C is already damaged!");
        }
    }

    internal void DamageCounter()
    {
        throw new NotImplementedException();
    }
}
