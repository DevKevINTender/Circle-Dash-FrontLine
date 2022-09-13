using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class DefaultBoxCom3D : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;
    public void InitComponent(Vector3 target)
    {
        rb.velocity = (target - transform.position).normalized * moveSpeed;
    }

    public void DestroyComponent()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<DestroyerCom>())
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        transform.Rotate(new Vector3(1,0,0) * rotateSpeed);
    }
}
