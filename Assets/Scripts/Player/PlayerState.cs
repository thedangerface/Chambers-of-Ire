using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State
    {
        idle,
        running,
        jumping,
        falling,
        landing,
        damaged,
        attacking,
        wallSliding,
        wallJump,
        facingRight
    }
    public State currentState;
    private float lastStateChange = 0.0f;

    public void Set(State state)
    {
        currentState = state;
        lastStateChange = Time.time;
    }
    void Start()
    {
        Set(State.idle);
    }

    // TODO: 
    // Player animation script should just trigger animations;
    // state machine should be in this script
    // states should be changed from player script
}
