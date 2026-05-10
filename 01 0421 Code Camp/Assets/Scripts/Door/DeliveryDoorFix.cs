using UnityEngine;
using UnityEngine.UI;

public class DeliveryDoorFix : Interactable
{
    [SerializeField] public float FixProgress = 0f;
    [SerializeField] private Image progressBar;
    [SerializeField] private DeliveryDoorDrop deliveryDoorDrop;

    private float maxBarWidth = 300f;

    private void Start()
    {
        progressBar.gameObject.SetActive(true);
    }

    // ADDED: This method reactivates the UI when called by the Drop script
    public void ShowUI()
    {
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(true);
        }
    }

    public override void Interact()
    {
        FixProgress += 0.1f;
        FixProgress = Mathf.Clamp(FixProgress, 0f, 1f);

        if (FixProgress >= 1f)
        {
            Debug.Log("Door fixed!");
            deliveryDoorDrop.FixDoor();
            progressBar.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (FixProgress >= 1f)
        {
            //Image stays at 0 when progress is 0
            var rect = progressBar.transform as RectTransform;
            rect.sizeDelta = new Vector2(0, rect.sizeDelta.y);
            return;
        }

        // decrease progress over time
        FixProgress -= 0.1f * Time.deltaTime;
        FixProgress = Mathf.Clamp(FixProgress, 0f, 1f);

        var theBarRectTransform = progressBar.transform as RectTransform;

        float reversedWidth = (1f - FixProgress) * maxBarWidth;

        theBarRectTransform.sizeDelta = new Vector2(reversedWidth, theBarRectTransform.sizeDelta.y);
    }

    public void ResetProgress()
    {
        FixProgress = 0f;
    }
}
