using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneAtIndex(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    public void Test() => Debug.Log("Test method called in GameManager");
}
