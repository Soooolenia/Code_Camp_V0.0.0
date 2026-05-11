using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image crosshair;
    [SerializeField] private GameObject progressBar;
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
    public void DeliveryDoorChange(bool on)
    {
        if (on)
        {
            ShowProgressBar();
        }
        else
        {
            HideProgressBar();
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
    public void ShowProgressBar()
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
    public void NoProgress()
    {
        var rect = progressBar.transform as RectTransform;
        rect.sizeDelta = new Vector2(0, rect.sizeDelta.y);
    }
    public void ProgressUpdate(float progress)
    {
        float reversedWidth = (1f - progress) * maxBarWidth;

        var theBarRectTransform = progressBar.transform as RectTransform;

        theBarRectTransform.sizeDelta = new Vector2(reversedWidth, theBarRectTransform.sizeDelta.y);
    }
}
