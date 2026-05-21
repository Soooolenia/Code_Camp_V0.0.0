using UnityEngine;
using UnityEngine.UI;

public class DeliveryDoorFix : Interactable
{
    [SerializeField] private float FixProgress = 0f;
    //[SerializeField] private Image progressBar;
    [SerializeField] private DeliveryDoorDrop deliveryDoorDrop;

    [SerializeField] private HUDManager hudManager;

    [SerializeField] private AudioSource deliveryDoorFix;
    [SerializeField] private AudioSource deliveryDoorFixed;
    public override void Interact()
    {
        FixProgress += 0.1f;
        FixProgress = Mathf.Clamp(FixProgress, 0f, 1f);

        deliveryDoorFix.Play();

        if (FixProgress >= 1f)
        {
            //Debug.Log("Door fixed!");
            deliveryDoorDrop.FixDoor();

            deliveryDoorFix.Play();

            hudManager.HideProgressBar();
        }
    }
    private void Update()
    {
        if (FixProgress >= 1f)
        {
            hudManager.ProgressUpdate(0f);
            hudManager.NoProgress();
            return;
        }
        //Decrease progress over time
        FixProgress -= 0.1f * Time.deltaTime;
        FixProgress = Mathf.Clamp(FixProgress, 0f, 1f);

        hudManager.ProgressUpdate(FixProgress);
    }
    public void ResetProgress()
    {
        FixProgress = 0f;
        hudManager.NoProgress();
    }
}
