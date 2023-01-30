using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyedEvent : BaseEvent
{
    public AsteroidBehaviour hitAsteroid { get; private set; }
    public AsteroidDestroyedEvent(AsteroidBehaviour hitAsteroid)
    {
        this.hitAsteroid = hitAsteroid;
    }
}
