using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartStory : MonoBehaviour
{
    public Camera MainCamera;
    public Camera StoryCamera;
    public GameObject Player;

    public TextMeshProUGUI Text;

    private bool Complete = false;

    gameManager gameManager;

    private void Awake()
    {
        gameManager = gameManager.I;
    }

    void Start()
    {
        if (gameManager.NewGame)
        {
            MainCamera.enabled = false;
            StoryCamera.enabled = true;

            Complete = false;

            gameManager.dayNightCycle.Pause = 0;

            StartCoroutine(StartStorySequence());
        }
        else
        {
            Complete = true;
        }
    }
    private void SwitchCamera()
    {
        MainCamera.enabled = !MainCamera.enabled;
        StoryCamera.enabled = !StoryCamera.enabled;
    }

    private void PlayerPosition()
    {
        Player.transform.position = new Vector3(-28.05f, -0.059f, -57.44f);
    }

    private IEnumerator StartStorySequence()
    {
        yield return new WaitForSeconds(9f);

        PlayerPosition();
        SwitchCamera();


        Complete = true;
    }

    void Update()
    {
        if (!Complete)
        {
            Input.ResetInputAxes();
            gameManager.dayNightCycle.Pause = 0;
        }
        else
        {
            gameManager.dayNightCycle.Pause = 1;
        }
    }

    private void WakeUp()
    {

    }
    //간수랑 대화
    //따라가기
    //
}
