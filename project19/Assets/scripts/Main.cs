using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        createMerkez();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public GameObject createPlanet(string name, Vector3 konum, float size){
        //GameObject ayarlari...
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.name = name;
        go.GetComponent<Renderer>().material = Instantiate(Resources.resources.beyaz);

        //anabina ayarlari...
        go.transform.position = konum;
        go.transform.localScale = new Vector3(size,size,size);

        //anabinayi dondur...
        return go;
    }
    public void createMerkez() {
        
        int alan = 100000;
        for(int i=0; i<50;i++){
            var merk = Merkez.create("MERKEZ[" + i + "]", new Vector3(Random.Range(-alan, alan), Random.Range(-alan, alan), Random.Range(-alan, alan)));
            Bina ekle = merk.anabina;
            for(int j=0; j<50; j++)
            {
                ekle = ekle.create(Bina.klist[Random.Range(0, Bina.klist.Count)], Bina.Varsa.silEkle);
            }
        }
        /*
        var merk = Merkez.create("MERKEZ[0]", new Vector3(0,0,0));
        Bina ekle = merk.anabina;
        for (int j = 0; j < 50; j++)
        {
            ekle = ekle.create(Bina.klist[Random.Range(0, Bina.klist.Count)], Bina.Varsa.silEkle);
        }*/
    }
}
