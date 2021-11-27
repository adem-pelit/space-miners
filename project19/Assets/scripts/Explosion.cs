﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float startingTime;
    public float duration;
    public Vector3 start;
    public Vector3 stop;
    public Light isik;
    public static Explosion create(Vector3 pos, Color color)
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = pos;
        go.name = "explosion";
        Destroy(go.GetComponent<SphereCollider>());
        var exp = go.AddComponent<Explosion>();
        exp.duration = 5;
        exp.start = new Vector3(1, 1, 1);
        exp.stop = new Vector3(100,100,100);

        exp.isik = go.AddComponent<Light>();
        exp.isik.color = color;
        exp.isik.range = 1000;
        exp.isik.intensity = 10;

        return exp;
    }
    public 
    void Start()
    {
        startingTime = Time.time;
        StartCoroutine(die());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(start, stop, (Time.time - startingTime) / duration);
        isik.intensity = Mathf.Lerp(0, 10, (Time.time - startingTime) / duration);
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
