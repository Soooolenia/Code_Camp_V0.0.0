using UnityEngine;

public class InteractablePartA : MonoBehaviour
{
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject damaged;
    [SerializeField] private GameObject broken;

    private void Awake()
    {
        good.SetActive(true);
        damaged.SetActive(false);
        broken.SetActive(false);
    }
    public void DamagePartA()
    {
        Debug.Log("Part A broke!");
        good.SetActive(false);
        damaged.SetActive(true);

    }
}
