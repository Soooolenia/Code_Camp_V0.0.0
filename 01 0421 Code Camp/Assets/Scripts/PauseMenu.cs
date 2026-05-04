using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    private bool isPaused = false;

    private StarterAssetsInputs _playerInputs;

    private void Awake()
    {
        _playerInputs = GetComponent<StarterAssetsInputs>();
    }
    private void OnPause(InputValue value)
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
}