using UnityEngine;

public class EnemyStateIdle : EnemyState
{
    public EnemyStateIdle(EnemyController enemy) : base(enemy)
    {

    }

    public override void Enter()
    {
        // Code to execute when entering the idle state
        enemy.Animation.PlayAnimation("Idle");
        enemy.Movement.EnemyStopMove();
    }
    public override void Update()
    {
        // Code to execute during the idle state update
        if (enemy.Data.enemyType == EnemyType.Undead && enemy.Summon.SummonCooldown())
        {
            enemy.ChangeState(new EnemyStateSummon(enemy));
            return;
        }
        if (enemy.Detection.PlayerCanBeTarget())
        {
            enemy.ChangeState(new EnemyStateRun(enemy));
            return;
        }
        if (enemy.Detection.PlayerInAttackZone())
        {
            if (!enemy.Combat.CanAttack()) return;
            enemy.ChangeState(new EnemyStateAttack(enemy));
            return;
        }

    }
    public override void Exit()
    {
        // Code to execute when exiting the idle state
    }
}