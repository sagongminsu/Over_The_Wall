using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollisonHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Attack On");
            // ���⿡ ���� ������ ���� �޾ƿͼ� ü�¿� ������ �ָ� �� ��?
        }
    }
}
