using UnityEngine;

public class Player : MonoBehaviour
{
    public bool GoodPartInHand = false;
    public bool BrokenPartInHand = false;

    [SerializeField] private GameObject badPartShowing;
    [SerializeField] private GameObject goodPartShowing;

    public void ShowBadObjectInHand()
    {
        badPartShowing.SetActive(true);
    }
    public void ShowGoodObjectInHand()
    {
        goodPartShowing.SetActive(true);
    }
    public void HideBadObjectInHand()
    {
        badPartShowing.SetActive(false);
    }
    public void HideGoodObjectInHand()
    {
        goodPartShowing.SetActive(false);
    }
}
