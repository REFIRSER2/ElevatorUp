using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPropController
{
    public void Init(Prop prop);
    public void Think();
}

public class PropController:IPropController
{
    private Prop prop;
    public void Init(Prop pr)
    {
        prop = pr;
    }

    public void Think()
    {
        Vector3 dir = (prop.transform.position - prop.GetData().targetPos).normalized;

        prop.transform.Translate(dir * (10F * Time.deltaTime));
    }
}
