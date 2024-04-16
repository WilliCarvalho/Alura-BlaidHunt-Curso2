using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager
{
    private PlayerControls playerControls;

    public float Movement => playerControls.Gameplay.Movement.ReadValue<float>();

    public event Action OnJump;
    public event Action OnAttack;
    public event Action OnMenuOpenClose;

    public InputManager()
    {
        playerControls = new PlayerControls();
        EnableGameplayInput();
        EnableUIInput();

        playerControls.Gameplay.Jump.performed += OnJumpPerformed;
        playerControls.Gameplay.Attack.performed += OnAttackPerformed;

        playerControls.UI.OpenCloseMenu.performed += OpenCloseMenuPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }
    
    private void OnAttackPerformed(InputAction.CallbackContext obj) => OnAttack?.Invoke();
    
    private void OpenCloseMenuPerformed(InputAction.CallbackContext obj)
    {
        if (SceneManager.GetActiveScene().name != "Gameplay") return;
        Debug.LogWarning("INVOKING PAUSE");
        OnMenuOpenClose?.Invoke();
    }

    public void DisableGameplayInput() => playerControls.Gameplay.Disable();

    public void EnableGameplayInput() => playerControls.Gameplay.Enable();

    public void EnableUIInput() => playerControls.UI.Enable();

    public void DisableUIInput() => playerControls.UI.Disable();
}
