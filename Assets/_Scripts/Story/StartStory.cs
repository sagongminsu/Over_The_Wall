using Cinemachine;
using System.Collections;
using UnityEngine;

public class StartStory : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject Player;

    gameManager gameManager;

    private void Awake()
    {
        gameManager = gameManager.I;
    }

    private void Start()
    {
        Debug.Log(gameManager.NewGame);
        if (gameManager.NewGame)
        {

            StartCoroutine(DisableVirtualCameraAfterDelay(4f));
        }
        else
        {

            virtualCamera.gameObject.SetActive(false);
        }
    }
    private IEnumerator DisableVirtualCameraAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        if (virtualCamera != null)
        {
            Player.transform.position = new Vector3(-28.05f, -0.059f, -57.44f);
            //Player.transform.position = new Vector3(50f, -0.1f, -21f);
            virtualCamera.gameObject.SetActive(false);
        }
    }
}

