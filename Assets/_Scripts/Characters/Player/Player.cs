using UnityEngine;

public class Player : MonoBehaviour
{   
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public WeaponColliderController Weapon_R{ get; private set; }
    public WeaponColliderController Weapon_L{ get; private set; }

    public AimUI Aim { get; private set; }
    

    public Rigidbody Rigidbody { get; private set; }
    public Animator PlayerAnimator { get; private set; }
    public Animator ArmAnimator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    public PlayerConditions Conditions { get; private set; }

    private PlayerStateMachine stateMachine;

    private void Awake()
    {

        AnimationData.Initialize();

        Conditions = GetComponent<PlayerConditions>();
        Rigidbody = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponentInChildren<Animator>();
        ArmAnimator = GetAnimator("Arm"); // �� ��° �ִϸ������� �̸��� ���
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        Weapon_R = GetWeapon("Weapon_R");
        Weapon_L = GetWeapon("Weapon_L");
        Aim = GetComponent<AimUI>();

        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();

    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    private WeaponColliderController GetWeapon(string weaponName)
    {
        WeaponColliderController weapon = GetComponentInChildren<WeaponColliderController>();

        if (weapon == null)
        {
            Debug.LogError($"No {weaponName} found in children. Make sure it's assigned in the Unity Inspector.");
        }

        return weapon;
    }

    private Animator GetAnimator(string animatorName)
    {
        // ������ �̸��� ���� �� ��° �ڽ� �ִϸ����͸� ã���ϴ�.
        Transform animatorTransform = transform.Find(animatorName);

        if (animatorTransform == null)
        {
            Debug.LogError($"{animatorName} �̸��� ���� �ڽ� �ִϸ����Ͱ� �����ϴ�. Unity Inspector���� �Ҵ�Ǿ����� Ȯ���ϼ���.");
            return null;
        }

        // ã�� �ڽĿ��� Animator ������Ʈ�� �����ɴϴ�.
        Animator animator = animatorTransform.GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError($"{animatorName}��(��) Animator ������Ʈ�� �����Ǿ� ���� �ʽ��ϴ�.");
        }

        return animator;
    }
}