using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCnt : MonoBehaviour
{
    private CircleCom circleComObj;
    void Start()
    {
        circleComObj = FindObjectOfType<CircleCom>();
    }
    
    public void Dash()
    {
        circleComObj.ChangeVector();
    }
}
