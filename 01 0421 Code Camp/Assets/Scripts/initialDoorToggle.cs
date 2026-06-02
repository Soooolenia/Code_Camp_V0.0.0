using UnityEngine;
using System.Threading.Tasks;   
public class initialDoorToggle : MonoBehaviour
{
    [SerializeField] private GameObject redButton;
    [SerializeField] private GameObject greenButton;
    [SerializeField] private GameObject buttonInteraction;

    [SerializeField] private AudioSource buttonSound;
    async void Start()
    {
        redButton.SetActive(true);
        greenButton.SetActive(false);
        buttonInteraction.SetActive(false);

        await Task.Delay(30000);

        buttonSound.Play();
        redButton.SetActive(false);
        greenButton.SetActive(true);
        buttonInteraction.SetActive(true);
    }
}
