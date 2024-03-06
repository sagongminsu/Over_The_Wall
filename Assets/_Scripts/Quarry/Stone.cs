using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    public float StoneSpeed = 400;
    public RectTransform rectTransform;
    public float minX = -300f; // �̵� ������ �ּ� X ��ǥ
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

        // �������� �̵� ���̰� �ִ� X ��ǥ�� �������� �� ������ �����մϴ�.
        if (moveRight && rectTransform.anchoredPosition.x >= maxX)
        {
            moveRight = false;
        }
        // �������� �̵� ���̰� �ּ� X ��ǥ�� �������� �� ������ �����մϴ�.
        else if (!moveRight && rectTransform.anchoredPosition.x <= minX)
        {
            moveRight = true;
        }
    }

}

