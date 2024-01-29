using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // 같은 GameObject에 붙어 있는 Animator 컴포넌트를 가져옵니다
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 실제 게임 로직으로 파라미터를 설정하면 됩니다
        animator.GetBool("isWalking");
        animator.GetBool("isAttacking");
        animator.GetBool("isFleeing");
        animator.GetBool("isRunning");
    }

    // 캐릭터가 걷기 시작하거나 멈출 때 이 메소드들을 호출합니다
    public void StartWalking()
    {
        animator.SetBool("isWalking", true);
    }

    public void StopWalking()
    {
        animator.SetBool("isWalking", false);
    }
    public void startFleeing()
    {
        animator.SetBool("isFleeing", true);
    }
    public void stopFleeing()
    {
        animator.SetBool("isFleeing", false);
    }
    public void startRunning()
    {
        animator.SetBool("isRunning", true);
    }
    public void StopRunning()
    {
        animator.SetBool("isRunning", false);
    }
}
