using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCnt : MonoBehaviour
{
    private CircleCom3D circleComObj;
    void Start()
    {
        circleComObj = FindObjectOfType<CircleCom3D>();
    }
    
    public void Dash()
    {
        circleComObj.ChangeVector();
    }
}
