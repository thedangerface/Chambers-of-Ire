using System.Collections;
using System.Collections.Generic;
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

    public Dictionary<State, bool> activeStates = new Dictionary<State, bool> ();

    private float lastStateChange = 0.0f;

    void Awake()
    {
        PopulateStateDict();
    }

    public void Set(State state, bool setActive)
    {
        activeStates[state] = setActive;
        lastStateChange = Time.time;
    }

    void Start()
    {
        Set(State.idle, true);

        foreach (KeyValuePair<State, bool> entry in activeStates)
        {
            Debug.Log(entry);
        }
    }

    private void PopulateStateDict() 
    {
        foreach (State state in System.Enum.GetValues(typeof(State)))  
        {  
            activeStates.Add(state, false);
        }  
    }

    public void ResetAllStates()
    {
        foreach (State state in System.Enum.GetValues(typeof(State)))  
        {  
            activeStates[state] = false;
        }
    }

    // TODO: 
    // Player animation script should just trigger animations;
    // state machine should be in this script
    // states should be changed from player script
}
