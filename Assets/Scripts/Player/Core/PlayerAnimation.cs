using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    private readonly int linearVelocityYHash = Animator.StringToHash("linearVelocityY");
    private readonly int[] attackStateHash =
    {
        Animator.StringToHash("Attack1"),
        Animator.StringToHash("Attack2"),
        Animator.StringToHash("Attack3"),
        Animator.StringToHash("Attack4")
    };
    private readonly int[] heavyAttackStateHash =
    {
        Animator.StringToHash("HeavyAttack1"),
        Animator.StringToHash("HeavyAttack2"),
        Animator.StringToHash("HeavyAttack3")
    };

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
    }

    public void SetAnimationState(string stateName)
    {
        animator.Play(stateName, 0, 0f);
    }

    public void SetAnimationFallState(float linearVelocityY)
    {
        animator.SetFloat(linearVelocityYHash, linearVelocityY);
    }

    public bool IsAnimationFinished()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f;
    }

    public void SetAnimationAttackState(int attackIndex)
    {
        animator.Play(attackStateHash[attackIndex], 0, 0f);
    }
    public void SetAnimationHeavyAttackState(int heavyAttackIndex)
    {
        animator.Play(heavyAttackStateHash[heavyAttackIndex], 0, 0f);
    }
    public void TriggerAttack()
    {
        playerController.NextAttack();
    }
    public void TriggerDamage()
    {
        playerController.Combat.PlayerAttack();
    }
    public void TriggerHeavyAttack()
    {
        playerController.NextHeavyAttack();
    }
    public void TriggerHeavyDamage()
    {
        playerController.Combat.PlayerHeavyAttack();
    }
    public void TriggerSkillDamage()
    {
        playerController.Combat.PlayerSkill();
    }
    public bool IsHurtFinished()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName("Hurt") && stateInfo.normalizedTime >= 1;
    }
    public bool IsDieFinished()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName("Die") && stateInfo.normalizedTime >= 1;
    }
    public void TriggerHealPotion()
    {
        playerController.Health.Heal(50f);
    }
}