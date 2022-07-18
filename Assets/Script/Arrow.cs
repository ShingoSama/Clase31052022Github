using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Vector3 m_Target;
    public float Speed;
    public Rigidbody rigidbody;
    private void Update()
    {
        float step = Speed * Time.deltaTime;
        if (m_Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Target, step);
        }
        //rigidbody.AddForce(Speed * rigidbody.velocity, ForceMode.Impulse);
    }
    public void SetTarget(Vector3 target)
    {
        m_Target = target;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }
    }
}
