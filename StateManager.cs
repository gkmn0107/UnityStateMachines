using System;
using System.Collections.Generic;
using UnityEngine;
public class StateManager<Estate> : MonoBehaviour where Estate : Enum
{
    //void Awake() { }
    protected Dictionary<Estate, BaseState<Estate>> States = new Dictionary<Estate, BaseState<Estate>>();

    protected BaseState<Estate> CurrentState;
    protected bool isTransitioningState = false;
    void Start(){
        CurrentState.EnterState();
    }
    void Update() {
        Estate nextStateKey = CurrentState.GetNextState();

        if (!isTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if (!isTransitioningState)
        {
            TransitionToState(nextStateKey);
        }
        
    }
    public void TransitionToState(Estate statekey)
    {
        isTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[statekey];
        CurrentState.EnterState();
        isTransitioningState = false;
    }
    void OnTriggerEnter(Collider other) {
        CurrentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other) {
        CurrentState.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other) {
        CurrentState.OnTriggerExit(other);
    }

    //void OnCollisionEnter(Collision other) { }
    
    //void OnCollisionStay(Collision other) { }
    
    //void OnCollisionExit(Collision other) { }
    
}
