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
        WrapPosition();
        
        if (timer > lifetime)
        {
            gameObject.SetActive(false);
            
        }
    }

    private void WrapPosition() {

        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y > 1 || screenPosition.y < 0)
        {
            gameObject.SetActive(false);
        }
        else {  
            
        transform.position = Camera.main.ViewportToWorldPoint(screenPosition);
        }
    }
}
