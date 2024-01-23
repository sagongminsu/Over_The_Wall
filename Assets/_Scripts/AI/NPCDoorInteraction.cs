//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class NPCDoorInteraction : MonoBehaviour
//{
//    public Transform door; // 문 오브젝트의 위치
//    private PushingDoor doorScript;
//    public float interactDistance = 1.5f; // 상호작용할 최대 거리

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
