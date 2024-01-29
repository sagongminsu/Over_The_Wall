using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // ���� GameObject�� �پ� �ִ� Animator ������Ʈ�� �����ɴϴ�
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ���� ���� �������� �Ķ���͸� �����ϸ� �˴ϴ�
        animator.GetBool("isWalking");
        animator.GetBool("isAttacking");
        animator.GetBool("isFleeing");
        animator.GetBool("isRunning");
    }

    // ĳ���Ͱ� �ȱ� �����ϰų� ���� �� �� �޼ҵ���� ȣ���մϴ�
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
