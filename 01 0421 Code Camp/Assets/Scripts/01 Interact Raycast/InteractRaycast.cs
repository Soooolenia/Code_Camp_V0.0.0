using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class InteractRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] LayerMask targetLayerMask;

    [SerializeField] private HUDManager hudManager;
    private void Update()
    {
        Vector3 fwd = transform.forward;

        bool canInteract = false;
        bool isDeliveryDoor = false;

        if (Physics.Raycast(transform.position, fwd, out RaycastHit hit, rayLength, targetLayerMask))
        {
            Interactable[] interactables = hit.collider.gameObject.GetComponentsInParent<Interactable>();

            foreach (Interactable interactable in interactables)
            {
                if (interactable.CanInteract())
                {
                    canInteract = true;

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        StopAllCoroutines();
                        //StartCoroutine(PlayLightGlow());
                        interactable.Interact();
                    }
                }
                DeliveryDoorFix deliverdoorfix = hit.collider.gameObject.GetComponentInParent<DeliveryDoorFix>();
                if (deliverdoorfix != null)
                {
                    isDeliveryDoor = true;
                }
            }
        }

        hudManager.CrosshairChange(canInteract);
        hudManager.DeliveryDoorChange(isDeliveryDoor);
    }
}
