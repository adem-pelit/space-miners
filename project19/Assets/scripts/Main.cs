using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main main;
    public RectTransform canv;
    public int score = 0;
    public List<AudioClip> audios;
    public Dictionary<string, RectTransform> resimler = new Dictionary<string, RectTransform>();
    public IEnumerator Start()
    {
        Main.main = this;
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
        go.GetComponent<Renderer>().material = Instantiate(Resource.resources.beyaz);

        //anabina ayarlari...
        go.transform.position = konum;
        go.transform.localScale = new Vector3(size,size,size);

        //anabinayi dondur...
        return go;
    }
    public void createMerkez() {
        int alan = 100000;
        for(int i=0; i<2;i++){
            var merk = Merkez.create("MERKEZ[" + i + "]", new Vector3(Random.Range(-alan, alan), Random.Range(-alan, alan), Random.Range(-alan, alan)));
            resimEkle(merk.name);
            Bina ekle = merk.anabina;
            for(int j=0; j<Random.Range(10,50); j++)
            {
                ekle = ekle.create(Bina.klist[Random.Range(0, Bina.klist.Count)], Bina.Varsa.silEkle);
            }
        }

    }
    public IEnumerator win()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel(0);
    }
    public void end()
    {
        StartCoroutine(win());
    }
    public RectTransform resimEkle(string name)
    {
        GameObject imgObject = new GameObject(name);

        RectTransform trans = imgObject.AddComponent<RectTransform>();
        trans.transform.SetParent(canv.transform); // setting parent
        trans.localScale = Vector3.one;
        trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        trans.sizeDelta = new Vector2(50, 50); // custom size

        Image image = imgObject.AddComponent<Image>();
        image.sprite = Resource.resources.target;
        imgObject.transform.SetParent(canv.transform);
        resimler.Add(name, trans);
        return trans;
    }
}
