using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class InteractRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] LayerMask targetLayerMask;

    //[SerializeField] private UnityEngine.UI.Image crosshair;
    [SerializeField] private HUDManager hudManager;
    private void Update()
    {
        Vector3 fwd = transform.forward;

        bool canInteract = false;

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
            }
        }

        hudManager.CrosshairChange(canInteract);
    }
}
