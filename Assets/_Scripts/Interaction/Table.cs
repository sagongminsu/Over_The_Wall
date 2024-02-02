using UnityEngine;

public class Table : MonoBehaviour
{
    public void OnInteract()
    {
        //장착하고 있던 식판 아이템 소모
        //의자에 앉아서 식사하는 애니메이션
        //플레이어 배고픔해소
    }
    public string GetInteractPrompt()
    {
        return "Interaction 식사하기";
    }
}
