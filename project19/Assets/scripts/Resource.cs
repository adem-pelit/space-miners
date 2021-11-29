using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public static Resource resources;
    public Material anaBina;
    public Material beyaz;
    public Sprite target;

    void Start()
    {
        Resource.resources = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
