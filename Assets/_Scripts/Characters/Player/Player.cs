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
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
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
}