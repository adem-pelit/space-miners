using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavasArac : Arac
{
    public static Transform t;
    void Start()
    {
        base.Start();
        if (BackgroundSound.bs != null) BackgroundSound.bs.set(transform);
    }        

    // Update is called once per frame
    void Update()
    {
        base.Update();

    }
}
