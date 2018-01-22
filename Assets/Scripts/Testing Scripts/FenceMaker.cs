using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FenceMaker : MonoBehaviour
{
    public Text textUIDis;
    public Text textUICount;
    public GameObject FencePole;
    public GameObject FenceFiller;
    private bool _placingWall = false;
    public bool placingWall { get { return _placingWall; } set { _placingWall = value;print(value); } }

    public float minDis = 0.3f;
    public float maxDis = 2f;

    GameObject fenceRoot;
    Vector3 MouseClickPos;
    //int poleCount = 0;
    List<GameObject> poles = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        if (Camera.main == null)
        {
            print("Main Camera is NULL!");
            Destroy(this);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!placingWall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fenceRoot = new GameObject("Fence Root");
                poles = new List<GameObject>();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000))
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
                        poles.Add(hit.transform.gameObject);
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
                foreach(GameObject t in poles)
                {
                    t.GetComponent<Collider>().enabled = true;
                }
                poles.Clear();
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000))
            {
                if (hit.transform.CompareTag("Terrain"))
                {
                    float dis = Vector3.Distance(MouseClickPos, hit.point);
                    textUIDis.text = dis.ToString();

                    if (dis < minDis)
                    {
                        if (poles[0].transform.childCount != 0)
                            Destroy(poles[0].transform.GetChild(0));
                        return;
                    }
                    dis /= poles.Count;
                    while(dis <= minDis&& poles.Count>1)
                    {
                        Destroy(poles[poles.Count-1]);
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
                    
                    textUICount.text = poles.Count.ToString();
                }
                else if (hit.transform.CompareTag("FencePole"))
                {
                    float dis = Vector3.Distance(MouseClickPos, hit.transform.position);
                    textUIDis.text = dis.ToString();

                    if (dis < minDis)
                    {
                        return;
                    }
                    dis /= poles.Count;
                    while (dis <= minDis && poles.Count > 1)
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
                        Vector3 posOfPole = ((hit.transform.position - MouseClickPos) / poles.Count) * i;
                        poles[i].transform.localPosition = posOfPole;
                        AddFiller(i);
                    }
                    poles.Add(hit.transform.gameObject);
                    AddFiller(poles.Count - 1);
                    poles.RemoveAt(poles.Count - 1);
                    textUICount.text = poles.Count.ToString();
                }
            }
        }
    }
    void AddFiller(int index)
    {
        GameObject go;
        if (poles[index - 1].transform.childCount > 0)
        {
            go = poles[index - 1].transform.GetChild(0).gameObject;
        }
        else
        {
            go = Instantiate(FenceFiller, poles[index - 1].transform);
        }
        go.transform.position = poles[index-1].transform.position;
        go.transform.localScale = new Vector3(Vector3.Distance(poles[index-1].transform.position, poles[index ].transform.position)/5,1,1);

        Vector3 direction = (go.transform.position - poles[index].transform.position).normalized;

        //create the rotation we need to be in to look at the target
        go.transform.rotation = Quaternion.LookRotation(direction);
        go.transform.Rotate(Vector3.up, -90);

    }
}
