using System;
using System.Collections;
using System.Collections.Generic;
using RF.Wave;
using UnityEngine;

public class Prop : MonoBehaviour
{
    #region 기본 내장 함수
    private void Awake()
    {
        if (controller != null)
        {
            controller.Init(this);
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (controller != null)
        {
            controller.Think();
        }    
    }
    #endregion
    
    #region 컨트롤러
    private IPropController controller = new PropController();

    public IPropController GetController()
    {
        return controller;
    }
    #endregion
    
    #region 데이터
    private IPropData data = new PropData();

    public IPropData GetData()
    {
        return data;
    }
    #endregion
}
