using UnityEngine;

public class EnemyStateSummon : EnemyState
{

    public EnemyStateSummon(EnemyController enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        enemy.Movement.EnemyStopMove();
        enemy.Animation.PlayAnimation("Summon");
        enemy.Audio.PlaySummonSound();
    }

    public override void Update()
    {
        enemy.Movement.EnemyStopMove();
        if (enemy.Animation.IsAnimationFinished("Summon"))
        {
            enemy.Summon.ActiveSummon();
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