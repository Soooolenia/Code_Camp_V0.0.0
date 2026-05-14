using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class InteractRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] LayerMask targetLayerMask;

    [SerializeField] private HUDManager hudManager;

    [SerializeField] private Interactable[] interactables;
    private void Update()
    {
        Vector3 fwd = transform.forward;

        bool canInteract = false;
        bool isDeliveryDoor = false;
        bool isDamagedPart = false;

        if (Physics.Raycast(transform.position, fwd, out RaycastHit hit, rayLength, targetLayerMask))
        {
            List<Interactable> prevInteractables = new List<Interactable>();

            if (interactables.Length > 0)
            {
                prevInteractables.AddRange(interactables);
            }

            interactables = hit.collider.gameObject.GetComponentsInParent<Interactable>();

            if (prevInteractables.Count > 0)
            {
                foreach (Interactable thisInteractable in prevInteractables)
                {
                    if (!interactables.Contains(thisInteractable))
                    {
                        thisInteractable.HoverExit();
                    }
                }
            }

            foreach (Interactable interactable in interactables)
            {
                if (interactable.CanInteract())
                {
                    canInteract = true;

                    interactable.HoverStay();

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        StopAllCoroutines();
                        //StartCoroutine(PlayLightGlow());
                        interactable.Interact();
                    }

                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        interactable.InteractHold();
                    }
                }

                    DeliveryDoorFix deliverdoorfix = hit.collider.gameObject.GetComponentInParent<DeliveryDoorFix>();
                if (deliverdoorfix != null)
                {
                    isDeliveryDoor = true;
                }

                DamagedPart damagedPart = hit.collider.gameObject.GetComponentInParent<DamagedPart>();
                if (damagedPart != null)
                {
                    isDamagedPart = true;
                }
            }

            hudManager.CrosshairChange(canInteract);
            hudManager.DeliveryDoorChange(isDeliveryDoor);
            hudManager.DamagedPartUIChange(isDamagedPart);

            Debug.Log("Can interact: " + canInteract);
        }
        else
        {
            if (interactables.Length > 0)
            {
                foreach (Interactable interactable in interactables)
                {
                    interactable.HoverExit();
                }
            }

            Debug.Log("Can interact: Hit nothing");

        }


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            foreach (Interactable thisInteractable in interactables)
            {
                thisInteractable.InteractStop();
            }
        }
    }
}
