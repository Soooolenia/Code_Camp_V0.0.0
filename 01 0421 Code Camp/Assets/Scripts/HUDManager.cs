using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image crosshair;
    [SerializeField] private GameObject progressBar;
    [SerializeField] private DeliveryDoorFix deliveryDoorFix;
    public float reversedWidth;

    private float maxBarWidth = 300f;
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
    public void ShowUI()
    {
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(true);
        }
    }

    public void HideProgressBar()
    {
        progressBar.gameObject.SetActive(false);
    }
    private void Update()
    {
        
    }
    public void NoProgress()
    {
        var rect = progressBar.transform as RectTransform;
        rect.sizeDelta = new Vector2(0, rect.sizeDelta.y);
    }

    public void ProgressUpdate()
    {
        float reversedWidth = (1f - deliveryDoorFix.FixProgress) * maxBarWidth;

        var theBarRectTransform = progressBar.transform as RectTransform;

        theBarRectTransform.sizeDelta = new Vector2(reversedWidth, theBarRectTransform.sizeDelta.y);
    }
}
