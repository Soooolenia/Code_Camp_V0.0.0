using UnityEngine;
using System.Collections;

public class PpManager : MonoBehaviour
{
    [SerializeField] private Animator startUp;

    [SerializeField] private MonoBehaviour playerControl;

    private void Awake()
    {
        playerControl.enabled = false;
    }
    void Start()
    {
        startUp.SetTrigger("StartUp");
        StartCoroutine(EnablePlayerControl());
    }

    private IEnumerator EnablePlayerControl()
    {
        yield return new WaitForSeconds(1.5f);
        playerControl.enabled = true;
    }
}
