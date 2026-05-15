using UnityEngine;
using System.Threading.Tasks;

public class DoorCollider : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource doorSlam;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Close");
        doorSlam.Play();
        GetComponent<Collider>().enabled = false;
    }
}
