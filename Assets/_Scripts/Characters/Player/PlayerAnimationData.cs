using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string groundParameterName = "@Ground";
  // [SerializeField] private string idleParameterName = "Idle";
  // [SerializeField] private string walkParameterName = "Walk";
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string hitParameterName = "Hit";

    [SerializeField] private string airParameterName = "@Air";
    [SerializeField] private string jumpParameterName = "Jump";
    [SerializeField] private string fallParameterName = "Fall";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string comboAttackParameterName = "ComboAttack";
    [SerializeField] private string meleeAttackParameterName = "MeleeAttack";
    [SerializeField] private string pickParameterName = "Pick";


    [SerializeField] private string aimingParameterName = "Aiming";
    [SerializeField] private string standingParameterName = "Standing";
    [SerializeField] private string crouchParameterName = "Crouch";



    public int GroundParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int HitParameterHash { get; private set; }

    public int AirParameterHash { get; private set; }
    public int JumpParameterHash { get; private set; }
    public int FallParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int ComboAttackParameterHash { get; private set; }
    public int MeleeAttackParameterHash { get; private set; }
    public int PickParameterHash { get; private set; }

    public int AimingParameterHash { get; private set; }
    public int StandingParameterHash { get; private set; }
    public int CrouchParameterHash { get; private set; }


    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
       // IdleParameterHash = Animator.StringToHash(idleParameterName);
       // WalkParameterHash = Animator.StringToHash(walkParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        HitParameterHash = Animator.StringToHash(hitParameterName);

        AirParameterHash = Animator.StringToHash(airParameterName);
        JumpParameterHash = Animator.StringToHash(jumpParameterName);
        FallParameterHash = Animator.StringToHash(fallParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        ComboAttackParameterHash = Animator.StringToHash(comboAttackParameterName);
        MeleeAttackParameterHash = Animator.StringToHash(meleeAttackParameterName);
        PickParameterHash = Animator.StringToHash(pickParameterName);


        AimingParameterHash = Animator.StringToHash(aimingParameterName);
        StandingParameterHash = Animator.StringToHash(standingParameterName);
        CrouchParameterHash = Animator.StringToHash(crouchParameterName);

    }
}