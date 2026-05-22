using UnityEngine;

public class MainButtonManager : MonoBehaviour
{
    public void BackToMainMenu()
    {
        GameManager.Instance.LoadSceneAtIndex(1);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Test()
    {
        Debug.Log("Options");
    }
}
