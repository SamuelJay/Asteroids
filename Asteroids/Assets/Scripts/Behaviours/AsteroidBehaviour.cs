using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : BaseObjectBehaviour
{
    private int stage;
    public void Setup(Manager manager, int speed, int stage)
    {
        base.Setup(manager);
        this.speed = speed;
        this.stage = stage;
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move();

    }
}
