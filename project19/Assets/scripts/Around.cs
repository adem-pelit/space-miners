using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Around : MonoBehaviour {
    public float speed;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton (0)) {
            transform.Rotate (0, Input.GetAxis ("Mouse X") * speed, 0);
            transform.position += new Vector3(0,-Input.GetAxis ("Mouse Y") * (speed/2),0);
        }
    }
}