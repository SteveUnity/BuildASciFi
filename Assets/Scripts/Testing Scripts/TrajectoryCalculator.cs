using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryCalculator : MonoBehaviour {

    public LineRenderer line;
    
    public int angle=45;
    public int v = 5;
    public float spacing = 1;
    [Space(10)]
    public GameObject projObj;
    public float toDestroy = 5;
    public bool fire = false;
    Vector3[] pos;
    // Use this for initialization
    void Start () {
        line.positionCount = 10;
        pos = new Vector3[10];


    }
	
	// Update is called once per frame
	void Update () {
        if (fire)
        {
            fire = !fire;
            projectile();
        }
        for (int i = 0; i < 10; i++)
        {
            float y = TrajY(i * spacing);
            pos[i] = new Vector3(i * spacing, y+transform.position.y);
/*            if (y>=0)
            {
                pos[i] = new Vector3(i * spacing, y);
            }
            else
            {
                pos[i] = new Vector3(i*spacing)
            }
  */      }
        line.SetPositions(pos);
	}

    float TrajY(float x)
    {
        float y = x * Mathf.Tan(angle) - (Physics.gravity.y*-1 * x * x) / (v * v * Mathf.Cos(angle)* Mathf.Cos(angle));
        return y;
    }
    void projectile()
    {
        GameObject go = Instantiate(projObj,transform.position,transform.rotation);

        var rot = Quaternion.AngleAxis(angle, Vector3.right);
        // that's a local direction vector that points in forward direction but also 45 upwards.
        var lDirection = (rot * Vector3.left) * v ;
        print(lDirection);
        //    go.GetComponent<Rigidbody>().AddForce(lDirection, ForceMode.Impulse);
        go.GetComponent<Rigidbody>().velocity = lDirection;
        Destroy(go, toDestroy);
    }
}
