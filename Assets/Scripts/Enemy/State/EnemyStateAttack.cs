using UnityEngine;

public class EnemyStateAttack : EnemyState
{
    private string attackName;

    public EnemyStateAttack(EnemyController enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        enemy.Movement.EnemyStopMove();
        attackName = enemy.Data.attackAnimations[enemy.Combat.attackIndex];
        enemy.Animation.PlayAnimation(attackName);
    }


    public override void Update()
    {
        if (!enemy.Animation.IsAnimationFinished(attackName))
        {
            return;
        }

        enemy.Combat.NextAttack();

        // Hết toàn bộ đòn: bắt đầu hồi rồi về Idle.
        enemy.Combat.StartAttackCooldown();
        enemy.ChangeState(new EnemyStateIdle(enemy));
    }
    public override void FixedUpdate()
    {
        // Code to execute during the attack state fixed update
    }
    public override void Exit()
    {
        // Code to execute when exiting the attack state
    }
}