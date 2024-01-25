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
            // 여기에 무기 데미지 값을 받아와서 체력에 영향을 주면 될 듯?
        }
    }
}
