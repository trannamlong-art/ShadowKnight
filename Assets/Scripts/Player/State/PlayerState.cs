using UnityEngine;

public class PlayerState
{
    public PlayerController player;
    public PlayerState(PlayerController player)
    {
        this.player = player;
    }

    public virtual void EnterState()
    {
        // Code to execute when entering the state
    }
    public virtual void UpdateState()
    {
        // Code to execute during the state update
    }
    public virtual void FixedUpdateState()
    {
    }

    public virtual void ExitState()
    {
        // Code to execute when exiting the state
    }
}
