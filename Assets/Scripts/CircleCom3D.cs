using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using static DefaultNamespace.SessionCore;
public class CircleCom3D : MonoBehaviour
{
    public float leftMax, rightMax;
    public bool isRight;
    private Coroutine currentMove;
    public float moveSpeed;
    private AddScoreDel addScoreDel;
    private LossDel lossDel;

    public void InitComponent(AddScoreDel addScoreDel, LossDel lossDel)
    {
        this.addScoreDel = addScoreDel;
        this.lossDel = lossDel;
        ChangeVector();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "DefaultBox3D":
            {
                other.GetComponent<DefaultBoxCom3D>().DestroyComponent();
                lossDel?.Invoke();
                break;
            }
            case "PointBox3D":
            {
                other.GetComponent<PointBoxCom3D>().DestroyComponent();
                addScoreDel?.Invoke();
                break;
            }
        }
    }

    public void ChangeVector()
    {
        if (isRight)
        {
            isRight = false;
            if(currentMove!=null) StopCoroutine(currentMove);
            currentMove = StartCoroutine(moveToMax(leftMax));
        }
        else
        {
            isRight = true;
            if(currentMove!=null) StopCoroutine(currentMove);
            currentMove = StartCoroutine(moveToMax(rightMax));
        }
    }
    public IEnumerator moveToMax(float max)
    {
        Vector3 target = new Vector3(max, transform.position.y, transform.position.z);
        while (transform.position.x != max)
        {
            transform.position = Vector3.MoveTowards(transform.position, target ,Time.deltaTime * moveSpeed );
            yield return null;
        }
        ChangeVector();
    }
}
