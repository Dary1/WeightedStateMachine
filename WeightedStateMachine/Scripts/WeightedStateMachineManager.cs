using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class WeightedStateMachineManager
{
    public List<WeightedState> ManagedWeightedStates;
    public WeightedState CurrentState;    

    public WeightedStateMachineManager() {
        ManagedWeightedStates = new List<WeightedState>();
    }

    public void Main() {
        // You can improve some performance here
        CurrentState = ManagedWeightedStates.OrderBy(f => f.Weight).First();
        CurrentState.StateMain();
    }

    public WeightedState CreateState(Action action)
    {
        return CreateState(action, 0);
    }

    public WeightedState CreateState(Action action,  float initialWeight) {
        
        WeightedState ws =  new WeightedState(action);
        ws.Weight = initialWeight;
        ManagedWeightedStates.Add(ws);
        return ws;
    }
}
