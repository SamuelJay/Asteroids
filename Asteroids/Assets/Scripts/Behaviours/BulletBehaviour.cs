using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : BaseObjectBehaviour
{
    private float lifetime;
    private float timer;
    public void Setup(Manager manager, int speed, float lifetime)
    {
        base.Setup(manager);
        this.speed = speed; 
        this.lifetime = lifetime;
        timer = 0;
    }
    protected override void Update()
    {
        base.Update();
        Move();
        timer+=Time.deltaTime;
        
        if (timer > lifetime)
        {
            gameObject.SetActive(false);
            
        }
    }
}
