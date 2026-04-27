using UnityEngine;

public class InteractablePartA : MonoBehaviour
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
    public void DamagePartA()
    {
        if (isDamaged == false)
        {
            Debug.Log("Part A broke!");
            good.SetActive(false);
            damaged.SetActive(true);

            isDamaged = true;;
        }
        else
        {
            Debug.Log("Part A is already damaged!");
        }
    }
}
