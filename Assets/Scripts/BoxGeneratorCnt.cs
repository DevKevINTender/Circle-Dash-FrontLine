using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BoxGeneratorCnt : MonoBehaviour
{
    public DefaultBoxCom3D defaultBoxPb;
    public PointBoxCom3D pointBoxPb;

    public float leftMax, rightMax;
    public float spawnRate;

    public Coroutine curentDelay;

    public int pointEveryBox;
    public int currentBox;
    public void InitCnt()
    {
        SpawnBox();
    }
    
    public void SpawnBox()
    {
        if(curentDelay != null) StopCoroutine(curentDelay);
        
        Vector3 spawnPos = new Vector2(Random.Range(leftMax,rightMax),transform.position.y);
        Vector3 targetPos = new Vector2(Random.Range(leftMax,rightMax),0);

        DefaultBoxCom3D newBox;
        if (currentBox != pointEveryBox)
        {
            newBox = Instantiate(defaultBoxPb, spawnPos, Quaternion.identity);
            currentBox++;
        }
        else
        {
            newBox = Instantiate(pointBoxPb, spawnPos, Quaternion.identity);
            currentBox = 0;
        }
        
        float signedAngle = Vector2.SignedAngle(newBox.transform.up, targetPos - newBox.transform.position);

        if (Mathf.Abs(signedAngle) >= 1e-3f)
        {
            var angles = newBox.transform.eulerAngles;
            angles.z += signedAngle;
            newBox.transform.eulerAngles = angles;
        }
        
        newBox.InitComponent(targetPos);

        curentDelay = StartCoroutine(spawnDelay());
    }

    public IEnumerator spawnDelay()
    {
        float timer = spawnRate;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        SpawnBox();
    }
}
