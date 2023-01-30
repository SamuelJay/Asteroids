using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : BaseObjectBehaviour
{
    public int stage { get; private set; }
    private int health;
    public void Setup(Manager manager,int health, int speed, int stage)
    {
        base.Setup(manager);
        this.health = health;
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

    private void OnCollisionEnter(Collision collision)
    {
        BulletBehaviour bullet= collision.gameObject.GetComponent<BulletBehaviour>();
        if (bullet!=null)
        {
            //Debug.Log("Asteroid Says Ouch!");
            health--;
            if (health <= 0)
            {
                TriggerEvent<AsteroidDestroyedEvent>(new AsteroidDestroyedEvent(this));
                bullet.gameObject.SetActive(false);
            }
        }
    }
}
