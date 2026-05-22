
using UnityEngine;

public class AudioDebugger : MonoBehaviour
{
    void Update()
    {
        // Press spacebar when you hear the glitch
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Note: FindObjectsOfType is fine, but FindObjectsByType is the updated standard
            AudioSource[] sources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

            foreach (AudioSource source in sources)
            {
                if (source.isPlaying)
                {
                    Debug.Log($"Currently Playing: {source.clip.name} on GameObject: {source.gameObject.name}");
                }
            }
        }
    }
}