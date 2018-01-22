using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFence : MonoBehaviour
{

    public GameObject FencePole;
    public GameObject FenceFiller;
    bool placingWall = false;

    public float minDis;
    public float maxDis;

    GameObject fenceRoot;
    Vector3 MouseClickPos;
    List<GameObject> poles;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (!placingWall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fenceRoot = new GameObject("FenceRoot");
                poles = new List<GameObject>();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.transform.CompareTag("Terrain"))
                    {
                        fenceRoot.transform.position = hit.point;
                        MouseClickPos = hit.point;
                        poles.Add(Instantiate(FencePole, hit.point, Quaternion.identity, fenceRoot.transform));
                        placingWall = true;
                    }
                    else if (hit.transform.CompareTag("FencePole"))
                    {
                        fenceRoot.transform.position = hit.transform.position;
                        MouseClickPos = hit.transform.position;
                        poles.Add(Instantiate(new GameObject(),hit.transform.position,Quaternion.identity,fenceRoot.transform));
                        placingWall = true;
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                placingWall = false;
                if(poles.Count>1 && !poles[0].CompareTag("FencePole"))
                {
                    poles[0].transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
                    poles[0].transform.GetChild(0).parent = poles[1].transform;
                    Destroy(poles[0]);
                    poles.RemoveAt(0);
                }
                else if(poles.Count==1 &&!poles[0].CompareTag("FencePole")){
                    poles[0].transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
                    return;
                }
                foreach (GameObject t in poles)
                {
                    t.GetComponent<Collider>().enabled = true;
                    if(t.transform.childCount>0)
                    t.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
                }
                poles.Clear();
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.transform.CompareTag("Terrain"))
                {
                    float dis = Vector3.Distance(MouseClickPos, hit.point);
                    if (dis < minDis)
                    {
                        if(poles[0].transform.childCount != 0)
                            Destroy(poles[0].transform.GetChild(0).gameObject);
                        return;
                    }
                    dis /= poles.Count;
                    while(dis <= minDis && poles.Count > 1)
                    {
                        Destroy(poles[poles.Count - 1]);
                        poles.RemoveAt(poles.Count - 1);
                        dis /= poles.Count;
                    }
                    while (dis > maxDis)
                    {
                        poles.Add(Instantiate(FencePole, hit.point, Quaternion.identity, fenceRoot.transform));
                        dis /= poles.Count;
                    }

                    for (int i = 1; i < poles.Count; i++)
                    {
                        Vector3 posOfPole = ((hit.point - MouseClickPos) / poles.Count) * i;
                        poles[i].transform.localPosition = posOfPole;
                        AddFiller(i);
                    }

                }
                else if (hit.transform.CompareTag("FencePole"))
                {
                    float dis = Vector3.Distance(MouseClickPos, hit.transform.position);

                    if (dis < minDis)
                        return;
                    dis /= poles.Count;
                    while(dis<= minDis && poles.Count > 1)
                    {
                        Destroy(poles[poles.Count - 1]);
                        poles.RemoveAt(poles.Count - 1);
                        dis /= poles.Count;
                    }
                    while (dis > maxDis)
                    {
                        poles.Add(Instantiate(FencePole, hit.transform.position, Quaternion.identity, fenceRoot.transform));
                        dis /= poles.Count;
                    }
                    for (int i = 1; i < poles.Count; i++)
                    {
                        Vector3 posOfPole = ((hit.transform.position - MouseClickPos) / poles.Count) * i;
                        poles[i].transform.localPosition = posOfPole;
                        AddFiller(i);
                    }
                    poles.Add(hit.transform.gameObject);
                    AddFiller(poles.Count - 1);
                    poles.RemoveAt(poles.Count - 1);
                }
            }
        }
    }
    void AddFiller(int index)
    {
        GameObject go;
        if (poles[index - 1].transform.childCount > 0)
            go = poles[index - 1].transform.GetChild(0).gameObject;
        else
            go = Instantiate(FenceFiller, poles[index - 1].transform);
        go.transform.position = poles[index - 1].transform.position;
        go.transform.localScale = new Vector3(1,1,Vector3.Distance(poles[index - 1].transform.position, poles[index].transform.position));

        Vector3 direction = (go.transform.position - poles[index].transform.position).normalized;

        go.transform.rotation = Quaternion.LookRotation(direction);
        //go.transform.Rotate(Vector3.up, -90);
    }
}
