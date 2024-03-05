using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    public float StoneSpeed = 400;
    public RectTransform rectTransform;
    public float minX = -300f; // 이동 가능한 최소 X 좌표
    public float maxX = 300f;

    private bool moveRight = true;

    private void Start()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }
    }
    void Update()
    {
        MoveStone();
    }
    private void MoveStone()
    {
        float movement = StoneSpeed * Time.deltaTime * (moveRight ? 1f : -1f);
        rectTransform.anchoredPosition += new Vector2(movement, 0f);

        // 우측으로 이동 중이고 최대 X 좌표에 도달했을 때 방향을 변경합니다.
        if (moveRight && rectTransform.anchoredPosition.x >= maxX)
        {
            moveRight = false;
        }
        // 좌측으로 이동 중이고 최소 X 좌표에 도달했을 때 방향을 변경합니다.
        else if (!moveRight && rectTransform.anchoredPosition.x <= minX)
        {
            moveRight = true;
        }
    }

}

