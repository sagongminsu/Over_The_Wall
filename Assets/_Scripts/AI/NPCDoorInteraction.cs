//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class NPCDoorInteraction : MonoBehaviour
//{
//    public Transform door; // �� ������Ʈ�� ��ġ
//    private PushingDoor doorScript;
//    public float interactDistance = 1.5f; // ��ȣ�ۿ��� �ִ� �Ÿ�

//    void Start()
//    {
//        doorScript = door.GetComponent<PushingDoor>();
//    }

//    void Update()
//    {
//        float distance = Vector3.Distance(transform.position, door.position);
//        if (distance <= interactDistance)
//        {
//            doorScript.OnInteract();
//        }
//    }
//}
