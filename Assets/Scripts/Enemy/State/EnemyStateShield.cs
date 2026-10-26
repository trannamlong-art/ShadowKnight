using UnityEngine;

public class EnemyStateShield : EnemyState
{
    private float shieldDuration; // Duration of the shield state in seconds
    public EnemyStateShield(EnemyController enemy) : base(enemy)
    {
        shieldDuration = enemy.Data.shieldTime;
    }

    public override void Enter()
    {
        // Code to execute when entering the shield state
        enemy.Animation.PlayAnimation("Shield");
        enemy.Movement.EnemyStopMove();
        enemy.Shield.StarBlocking();
    }
    public override void Update()
    {
        // Code to execute during the shield state update
        shieldDuration -= Time.deltaTime;
        if (enemy.Detection.PlayerInDetectionZone())
        {
            enemy.Movement.EnemyFlip(enemy.Detection.ToPlayer.x);
        }

        if (shieldDuration <= 0)
        {
            enemy.ChangeState(new EnemyStateIdle(enemy));
        }
    }
    public override void Exit()
    {
        // Code to execute when exiting the shield state
        enemy.Shield.DisableShield();
        enemy.Shield.ActiveShieldColdown();
    }
}