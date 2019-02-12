using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedState
{
    public float Weight;
    public Action Action;
    public WeightedState( Action Action) {
        this.Action = Action;
    }


    public void StateMain() {
        Action.Invoke();
    }

}
