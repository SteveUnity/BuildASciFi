using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableManager : MonoBehaviour {

    [SerializeField]
    public List<ScriptableObject> Bs = new List<ScriptableObject>();
    public List<Vector3> vec = new List<Vector3>();
	
    public void Start()
    {
        print("Start in ScriptableManager");
        if (Bs.Count > 0)
        {
            print(Bs[0].GetType().ToString());
            
        }
    }

}
