using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public LayerMask gearLayer;

    public float movementSpeed;
    public bool isVertical;

    int directionMovement = 1;
    void Start()
    {
        
    }
    void Update()
    {
        if (GearDetected())
        {
            Flip();
        }
        Moving();
    }
    private void Moving()
    {
        if (isVertical)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + movementSpeed * Time.deltaTime * directionMovement, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime * directionMovement, transform.position.y, transform.position.z);
        }
    }
    private bool GearDetected()
    {
        return Physics.CheckSphere(transform.position, 0.6f, gearLayer);
    }
    public void Flip()
    {
        directionMovement *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.6f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(gameObject);
        }
    }
}
