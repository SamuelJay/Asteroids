using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadedEvent : BaseEvent
{
    public Scene scene { get; private set; }
    public LoadSceneMode mode { get; private set; }

    public SceneLoadedEvent(Scene sceneIn, LoadSceneMode modeIn)
    {
        scene = sceneIn;
        mode = modeIn;
    }
}
