using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class DefaultBoxCom : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public void InitComponent(Vector3 target)
    {
        rb.velocity =  (target - transform.position).normalized * moveSpeed;
    }

    public void DestroyComponent()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<DestroyerCom>())
        {
            Destroy(gameObject);
        }
    }
}
