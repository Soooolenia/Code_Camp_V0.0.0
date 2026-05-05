using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;

    [SerializeField] private GameObject pauseMenuUI;
    private bool isPaused = false;

    private StarterAssetsInputs _playerInputs;

    private void Awake()
    {
        _playerInputs = GetComponent<StarterAssetsInputs>();
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

        //Handle the Cursor
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;

        //Update StarterAssets Controller
        //Stops the camera from spinning and the player from moving while paused
        if (_playerInputs != null)
        {
            _playerInputs.cursorLocked = !isPaused;
            _playerInputs.cursorInputForLook = !isPaused;

            // Optional: Reset move input so the player doesn't keep sliding
            _playerInputs.move = Vector2.zero;
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
    }
}