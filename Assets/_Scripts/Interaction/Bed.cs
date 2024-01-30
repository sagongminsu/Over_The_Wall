using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public void OnInteract()
    {
       //침대위에 눕기 애니메이션 실행
       //현재 시점으로 저장
       //피곤함,체력 등 회복
    }
    public string GetInteractPrompt()
    {
        return "Interaction 잠자기";
    }
}
