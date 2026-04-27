using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class InteractRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;

    [SerializeField] private UnityEngine.UI.Image crosshair;
    //[SerializeField] private Animator wandLightAnim;


    private void OnEnable()
    {
        crosshair.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if (crosshair != null)
        {
            crosshair.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Vector3 fwd = transform.forward;

        bool canInteract = false;

        if (Physics.Raycast(transform.position, fwd, out RaycastHit hit, rayLength))
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

        CrosshairChange(canInteract);
    }

    public void CrosshairChange(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }
}
