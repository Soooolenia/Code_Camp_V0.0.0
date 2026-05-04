using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public void startButton()
    {
        GameManager.Instance.LoadSceneAtIndex(2);
        Debug.Log("Start Button Pressed");
    }
    public void optionButton()
    {
        Debug.Log("Option Button Pressed");
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
}
