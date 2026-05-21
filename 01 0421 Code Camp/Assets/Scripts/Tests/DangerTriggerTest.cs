using UnityEngine;

public class DangerTriggerTest : MonoBehaviour
{
    [SerializeField] private MusicManager musicManager;
    private void OnTriggerEnter(Collider other)
    {
        musicManager.StartDangerLoop();
    }
}
