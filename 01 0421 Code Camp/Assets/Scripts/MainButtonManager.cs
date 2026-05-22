using UnityEngine;

public class MainButtonManager : MonoBehaviour
{
    public void BackToMenu()
    {
        GameManager.Instance.LoadSceneAtIndex(1);
    }
}
