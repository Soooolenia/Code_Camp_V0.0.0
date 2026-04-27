using UnityEngine;

public class InteractablePartB : MonoBehaviour
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
    public void DamagePartB()
    {
        Debug.Log("Part B broke!");
        good.SetActive(false);
        damaged.SetActive(true);
    }
}
