using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBehaviour : BaseBehaviour
{
    private State state;

    public void SetState(State state) 
    {
        this.state = state;
    }
}
