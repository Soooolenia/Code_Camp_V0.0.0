using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;

    [SerializeField] private GameObject pauseMenuUI;

    public bool isPaused = false;

    private StarterAssetsInputs _playerInputs;

    private void Awake()
    {
        _playerInputs = GetComponent<StarterAssetsInputs>();
        if (_playerInputs == null)
        {
            _playerInputs = FindFirstObjectByType<StarterAssetsInputs>();
        }

        Debug.Log(gameObject.name);
    }
    public void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        //Show/Hide the Menu
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(isPaused);
        }

        //Freeze/Unfreeze Time
        Time.timeScale = isPaused ? 0f : 1f;

        if (_playerInputs != null)
        {
            _playerInputs.cursorLocked = !isPaused;
            _playerInputs.cursorInputForLook = !isPaused;

            _playerInputs.move = Vector2.zero;
            _playerInputs.look = Vector2.zero;
        }

        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;

        if (_playerInputs != null)
        {
            _playerInputs.SetCursorState(_playerInputs.cursorLocked);
        }
    }
    

    public void ToggleOptions()
    {
        optionsPanel.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void BackToPauseMenu()
    {
        optionsPanel.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void QuitGame()
    {
        GameManager.Instance.LoadSceneAtIndex(1);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Reset time scale
        Time.timeScale = 1f;
    }
    public void Test()
    {
        Debug.Log("Options");
    }
}