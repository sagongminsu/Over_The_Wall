using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [field: SerializeField] public RightWeapon RightHandWeapon { get; private set; }
    [field: SerializeField] public LeftWeapon LeftHandWeapon { get; private set; }
   
    public AIHealth AiHealth { get; private set; }

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
        AiHealth = GetComponent<AIHealth>();

        List<Transform> waypoints = new List<Transform>();
        stateMachine = new AiStateMachine(this, waypoints);
        //// 'Waypoint' �±װ� �ִ� ��� ���� ������Ʈ�� ã�Ƽ� ����Ʈ�� �߰��մϴ�.
        //List<Transform> waypoints = new List<Transform>(GameObject.FindGameObjectsWithTag("Waypoint").Select(go => go.transform));

        //// AiStateMachine�� ������ �� ��������Ʈ ����Ʈ�� �����մϴ�.
        //stateMachine = new AiStateMachine(this, waypoints);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleingState);
        AiHealth.OnDie += OnDie;
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();

        // NavMeshAgent�� �ӵ��� üũ�Ͽ� �ִϸ��̼� �Ķ���� ����
        float speed = Agent.velocity.magnitude;
        Animator.SetFloat("Speed", speed);
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    void OnDie()
    {
        Animator.SetTrigger("Die");
        enabled = false;
    }
}
