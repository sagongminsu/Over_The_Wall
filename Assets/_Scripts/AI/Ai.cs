using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public AiSO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }
    public CharacterController Controller { get; private set; }

    private AiStateMachine stateMachine;
    public NavMeshAgent Agent { get; private set; }
    void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        Agent = GetComponent<NavMeshAgent>();

        stateMachine = new AiStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleingState);
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();

        // NavMeshAgent의 속도를 체크하여 애니메이션 파라미터 설정
        float speed = Agent.velocity.magnitude;
        Animator.SetFloat("Speed", speed);
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
}
