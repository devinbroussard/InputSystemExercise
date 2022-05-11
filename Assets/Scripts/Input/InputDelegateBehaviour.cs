using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehaviour : MonoBehaviour
{
   private PlayerControls _playerControls;

   private void OnEnable()
   {
       _playerControls.Enable();
   }

   private void OnDisable()
   {
       _playerControls.Disable();
   }

   private PlayerMovementBehaviour _playerMovement;
   [SerializeField]
   private ProjectileSpawnerBehaviour _gun;

   private void Awake()
   {
        _playerControls = new PlayerControls();
        _playerMovement = GetComponent<PlayerMovementBehaviour>();
   }

    void Start()
    {
        _playerControls.Ship.Shoot.performed += (context) => { _gun.Fire(); };
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = _playerControls.Ship.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }

    
}
