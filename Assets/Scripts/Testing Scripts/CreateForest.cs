using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateForest : MonoBehaviour
{

    public List<GameObject> Trees;

    public float circleSize = 1;
    public float speed = 0.5f;
    public float spacing = 1.6f;

    public bool Generate = false;

    GameObject forest;

    private void Start()
    {
        forest = new GameObject("Forest");
        forest.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = (speed < 0) ? 0 : speed;
        spacing = (spacing < 1.2f) ? 1.2f : spacing;
        if (Generate)
        {
            StopAllCoroutines();
           
            StartCoroutine(GenerateForest());
            Generate = false;

        }
    }

    IEnumerator GenerateForest()
    {
        while(true)
        {
            yield return new WaitForSeconds(speed);
            Vector2 randLoc = Random.insideUnitCircle * circleSize;
            Vector3 LocInWorld = new Vector3(randLoc.x + transform.position.x, 0, randLoc.y + transform.position.z);
            RaycastHit hit;
            if (Physics.SphereCast(new Vector3(LocInWorld.x, 8.5f, LocInWorld.z), spacing, Vector3.down, out hit,20f))
            {
                if(hit.transform.gameObject.layer == 8)
                {
                    GameObject tree = Instantiate(Trees[Random.Range(0,Trees.Count)], forest.transform);
                    tree.transform.position = LocInWorld;
                    tree.transform.Rotate(0, Random.Range(0, 359.9f), 0);
                }
                
            }
           
        }

    }
}
