using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : BaseObjectBehaviour
{
    public void Setup(Manager manager,int speed)
    {
        base.Setup(manager);
        this.speed = speed; 
    }
    protected override void Update()
    {
        base.Update();
        Move();
    }
}
