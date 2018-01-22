using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSelection : MonoBehaviour {

    public GameObject quad;
    public Texture RedTex;
    public Texture GreenTex;
    public new Camera camera;
    public Vector2 size;

    private void Start()
    {
        quad.GetComponent<Renderer>().sharedMaterial.mainTexture = GreenTex;
    }

    // Update is called once per frame
    

    public Transform StartInst(Vector2 size)
    {
        this.size = size;
        Transform quadInst = Instantiate(quad, Vector3.zero, quad.transform.rotation).transform;
        quadInst.localScale = new Vector3(size.x, size.y, 1);
        quadInst.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(size.x, size.y));
        return quadInst;
    }
}
