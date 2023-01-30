using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjectBehaviour : BaseBehaviour
{
    protected int speed;
    protected virtual void Update()
    {
        WrapPosition();
    }
    private void WrapPosition()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.x < 0)
        {
            screenPosition.x = 1;
        }

        if (screenPosition.x > 1)
        {
            screenPosition.x = 0;
        }

        if (screenPosition.y > 1)
        {
            screenPosition.y = 0;
        }

        if (screenPosition.y < 0)
        {
            screenPosition.y = 1;
        }

        transform.position = Camera.main.ViewportToWorldPoint(screenPosition);
    }

    protected void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
