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
        enemy.Combat.NextAttack();
        enemy.Combat.StartAttackCooldown();

        if (enemy.Animation.IsAnimationFinished(attackName) && enemy.Detection.PlayerInDetectionZone())
        {
            enemy.ChangeState(new EnemyStateRun(enemy));
            return;
        }
        if (enemy.Animation.IsAnimationFinished(attackName) && !enemy.Detection.PlayerInDetectionZone())
        {
            enemy.ChangeState(new EnemyStateIdle(enemy));
        }
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