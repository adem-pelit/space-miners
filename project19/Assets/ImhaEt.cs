using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImhaEt : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
