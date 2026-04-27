using UnityEngine;

public class InteractablePartC : MonoBehaviour
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
    public void DamagePartC()
    {
        Debug.Log("Part C broke!");
        good.SetActive(false);
        damaged.SetActive(true);
    }
}
