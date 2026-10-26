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
        enemy.gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
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