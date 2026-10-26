using UnityEngine;
using UnityEngine.InputSystem;

public class Playerinput : MonoBehaviour
{
    public Vector2 moveInput { get; private set; }
    public bool jumpInput { get; private set; }
    public bool attackInput { get; private set; }
    public bool heavyAttackInput { get; private set; }
    public bool rollingInput { get; private set; }
    public bool healingInput { get; private set; }
    public bool skillInput { get; private set; }

    private InputAction activeMoveAction;
    private InputAction activeJumpAction;
    private InputAction activeAttackAction;
    private InputAction activeHeavyAttackAction;
    private InputAction activeRollingAction;
    private InputAction activeHealingAction;
    private InputAction activeSkillAction;

    private bool isActive;
    private void OnEnable()
    {
        activeMoveAction = InputSystem.actions?.FindAction("Player/Move");
        activeJumpAction = InputSystem.actions?.FindAction("Player/Jump");
        activeAttackAction = InputSystem.actions?.FindAction("Player/Attack");
        activeHeavyAttackAction = InputSystem.actions?.FindAction("Player/HeavyAttack");
        activeRollingAction = InputSystem.actions?.FindAction("Player/Sprint");
        activeHealingAction = InputSystem.actions?.FindAction("Player/Heal");
        activeSkillAction = InputSystem.actions?.FindAction("Player/Interact");

        activeMoveAction.Enable();
        activeJumpAction.Enable();
        activeAttackAction.Enable();
        activeHeavyAttackAction.Enable();
        activeRollingAction.Enable();
        activeHealingAction.Enable();
        activeSkillAction.Enable();
    }
    public void InputActive()
    {
        if (isActive) return;

        moveInput = activeMoveAction != null && isActiveAndEnabled
            ? activeMoveAction.ReadValue<Vector2>()
            : Vector2.zero;

        jumpInput = activeJumpAction != null && isActiveAndEnabled
            ? activeJumpAction.triggered
            : false;

        attackInput = activeAttackAction != null && isActiveAndEnabled
            ? activeAttackAction.triggered
            : false;

        heavyAttackInput = activeHeavyAttackAction != null && isActiveAndEnabled
            ? activeHeavyAttackAction.triggered
            : false;

        rollingInput = activeRollingAction != null && isActiveAndEnabled
            ? activeRollingAction.triggered
            : false;

        healingInput = activeHealingAction != null && isActiveAndEnabled
            ? activeHealingAction.triggered
            : false;

        skillInput = activeSkillAction != null && isActiveAndEnabled
            ? activeSkillAction.triggered
            : false;
    }

    public void DisableButton(bool isActive)
    {
        this.isActive = isActive;
    }

}
