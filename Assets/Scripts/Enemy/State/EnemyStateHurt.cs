using UnityEngine;

public class EnemyStateHurt : EnemyState
{
    public EnemyStateHurt(EnemyController enemy) : base(enemy)
    {

    }

    public override void Enter()
    {
        enemy.Animation.PlayAnimation("Hurt");
    }
    public override void Update()
    {
        if (enemy.Shield != null && enemy.Shield.CanActivateShield() && enemy.Animation.IsAnimationHurtFinished())
        {
            // If the shield is active, the enemy should not be in the hurt state
            enemy.ChangeState(new EnemyStateShield(enemy));
            return;
        }
        if (enemy.Animation.IsAnimationHurtFinished())
        {
            enemy.ChangeState(new EnemyStateIdle(enemy));
        }

    }
    public override void Exit()
    {

    }
}