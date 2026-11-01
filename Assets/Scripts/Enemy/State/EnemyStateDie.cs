using UnityEngine;

public class EnemyStateDie : EnemyState
{
    public EnemyStateDie(EnemyController enemy) : base(enemy)
    {

    }

    public override void Enter()
    {
        // Code to execute when entering the die state
        enemy.Movement.EnemyStopMove();
        enemy.Animation.PlayAnimation("Die");
        enemy.gameObject.tag = "DeadEnemy";

        if (enemy.Summon != null)
        {
            enemy.Summon.DisableSummon();
        }
    }
    public override void Update()
    {
        // Code to execute during the die state update
        if (enemy.Animation.IsAnimationDieFinished())
        {
            enemy.gameObject.SetActive(false);
        }
    }
    public override void Exit()
    {
        // Code to execute when exiting the die state
    }
}