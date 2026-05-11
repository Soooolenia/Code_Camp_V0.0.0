using UnityEngine;

public class DeliveryDoorDrop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private DeliveryDoorFix deliveryDoorFix;
    [SerializeField] private DeliveryDoorManager deliveryDoorManager;

    private void OnTriggerEnter(Collider other)
    {
        var doorDropChance = Random.Range(0f, 1f);
        if (doorDropChance <= 1f)
        {
            if (!deliveryDoorManager.IsBroken())
            {
                Debug.Log("is not broken");
                DropDoor();
                Debug.Log("Drop Door");
            }
        }
    }

    private void DropDoor()
    {
        // ADDED: Tell the manager the door is now broken
        deliveryDoorManager.SetBrokenState(true);

        animator.ResetTrigger("Fix");
        animator.SetTrigger("Drop");

        deliveryDoorFix.enabled = true;
        // ADDED: Tell the fix script to show the UI again
        deliveryDoorFix.ShowUI();
    }

    public void FixDoor()
    {
        // ADDED: Tell the manager the door is fixed
        deliveryDoorManager.SetBrokenState(false);

        animator.ResetTrigger("Drop");
        animator.SetTrigger("Fix");

        deliveryDoorFix.ResetProgress();
        deliveryDoorFix.enabled = false;
    }
}
