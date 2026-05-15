using UnityEngine;

public class DeliveryDoorDrop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private DeliveryDoorFix deliveryDoorFix;
    [SerializeField] private DeliveryDoorManager deliveryDoorManager;

    [SerializeField] private HUDManager hudManager;

    //[SerializeField] private GameObject progressText;

    private void OnTriggerEnter(Collider other)
    {
        var doorDropChance = Random.Range(0f, 1f);
        if (doorDropChance <= 0.2f)
        {
            if (!deliveryDoorManager.IsBroken())
            {
                Debug.Log("is not broken");
                DropDoor();
                Debug.Log("Drop Door");
            }
        }
    }

    public void DropDoor()
    {
        //Tell the manager the door is now broken
        deliveryDoorManager.SetBrokenState(true);

        animator.ResetTrigger("Fix");
        animator.SetTrigger("Drop");

        deliveryDoorFix.enabled = true;
        //Tell the fix script to show the UI again
        hudManager.ShowProgressBar();
        //progressText.SetActive(true);

    }

    public void FixDoor()
    {
        //Tell the manager the door is fixed
        deliveryDoorManager.SetBrokenState(false);

        animator.ResetTrigger("Drop");
        animator.SetTrigger("Fix");

        deliveryDoorFix.ResetProgress();
        deliveryDoorFix.enabled = false;
        //progressText.SetActive(false);
    }
}
