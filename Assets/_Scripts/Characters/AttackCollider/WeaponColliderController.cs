using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliderController : MonoBehaviour
{
    public BoxCollider[] Weapons;

    private void Start()
    {
        Weapons = GetComponentsInChildren<BoxCollider>();
    }

    public void ToggleColliders(bool enable)
    {
        foreach (var weapon in Weapons)
        {
            weapon.enabled = enable;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
       // AiStateMachine aiStateMachine = collider.GetComponentInParent<AiStateMachine>();
      //  if (aiStateMachine != null)
      //  {
      //       aiStateMachine.OnAttacked();
       // }
    }
}
