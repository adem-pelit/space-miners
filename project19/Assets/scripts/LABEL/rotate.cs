using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rote());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0,Time.deltaTime,0);
    }
    IEnumerator rote(){
    yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 360; i++)
        {
            transform.position = new Vector3(Mathf.Sin(Mathf.Deg2Rad*i)*3,3,Mathf.Cos(Mathf.Deg2Rad*i)*3);
            transform.LookAt(Labeling.labeling.transform.position);
            Labeling.labeling.save("dataset/image "+i.ToString("000"));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
