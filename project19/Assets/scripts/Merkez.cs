using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merkez : MonoBehaviour
{
    public AnaBina anabina;
    public static List<Bina> binas = new List<Bina>();
    public static List<Merkez> merkezs = new List<Merkez>();
    //public iliski;
    // Start is called before the first frame update
    public static Merkez create(string name, Vector3 pos)
    {
        var go = new GameObject(name);
        go.transform.position = pos;
        var merkez = go.AddComponent<Merkez>();
        merkez.anabina = AnaBina.create(merkez, new Vector3Int(0, 0, 0), 500);
        if (binas == null) binas = new List<Bina>();
        binas.Add(merkez.anabina);
        if (merkezs == null) merkezs = new List<Merkez>();
        merkezs.Add(merkez);
        return merkez;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anabina == null)
        {
            merkezs.Remove(this);
            Destroy(gameObject);
        }
    }
}
