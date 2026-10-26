using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private EnemyCombat enemyCombat;
    private EnemyController enemy;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyCombat = GetComponent<EnemyCombat>();
        enemy = GetComponent<EnemyController>();
    }

    public void PlayAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.Play(animationName, 0, 0f);
        }
    }
    public bool IsAnimationFinished(string animationName)
    {
        var state = animator.GetCurrentAnimatorStateInfo(0);

        return state.IsName(animationName) && state.normalizedTime >= 1f;
    }
    public bool IsAnimationDieFinished()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        return state.IsName("Die") && state.normalizedTime >= 1f;
    }
    public bool IsAnimationHurtFinished()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        return state.IsName("Hurt") && state.normalizedTime >= 1f; ;
    }
    public void TriggerDamageAttack()
    {
        enemyCombat.EnemyAttack();
    }
    public void TriggerBackDash()
    {
        enemy.Movement.EnemyBackDash(enemy.Data.DashForce);
    }
    public void TriggerForwardDash()
    {
        enemy.Movement.EnemyForwardDash(enemy.Data.DashForce);
    }
}
