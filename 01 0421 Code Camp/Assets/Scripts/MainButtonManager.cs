using UnityEngine;

public class MainButtonManager : MonoBehaviour
{
    public void BackToMainMenu()
    {
        GameManager.Instance.LoadSceneAtIndex(1);

        Cursor.lockState = false ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
