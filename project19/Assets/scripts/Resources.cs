using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public static Resources resources;
    public Material anaBina;
    public Material beyaz;

    void Start()
    {
        Resources.resources = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
