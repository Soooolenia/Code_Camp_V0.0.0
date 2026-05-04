using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    public void startButton()
    {
        GameManager.Instance.LoadSceneAtIndex(2);
        Debug.Log("Start Button Pressed");

        Cursor.lockState = CursorLockMode.Locked;
    }
    public void optionButton()
    {
        Debug.Log("Option Button Pressed");
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void creditButton()
    {
        Debug.Log("Credit Button Pressed");
    }
    public void quitButton()
    {
        Application.Quit();
        Debug.Log("Quit Button Pressed");
    }

    public void backButton()
    {
        Debug.Log("Back Button Pressed");
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
}
