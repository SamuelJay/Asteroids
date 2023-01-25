using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public Manager manager { get; private set; }
    public virtual void Setup(Manager manager)
    {
        this.manager = manager;
    }
}
