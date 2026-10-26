using UnityEngine;

public class EnemyStateRun : EnemyState
{
    public EnemyStateRun(EnemyController enemy) : base(enemy)
    {

    }

    public override void Enter()
    {
        // Code to execute when entering the run state
        enemy.Animation.PlayAnimation("Run");
    }
    public override void Update()
    {
        // Code to execute during the run state update
        enemy.Movement.EnemyFlip(enemy.Detection.ToPlayer.x);

        if (!enemy.Detection.PlayerInDetectionZone())
        {
            enemy.ChangeState(new EnemyStateIdle(enemy));
            return;
        }
        if (enemy.Detection.PlayerInAttackZone())
        {
            if (!enemy.Combat.CanAttack()) return;
            enemy.ChangeState(new EnemyStateAttack(enemy));
            return;
        }
    }
    public override void FixedUpdate()
    {
        // Code to execute during the run state fixed update
        enemy.Movement.EnemyMove(enemy.Detection.ToPlayer);
    }
    public override void Exit()
    {
        // Code to execute when exiting the run state
    }
}