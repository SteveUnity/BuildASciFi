using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestsManager : MonoBehaviour {

    public List<forest> forests = new List<forest>();

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }


    public class forest
    {
        public List<GameObject> trees = new List<GameObject>();
        public int treesCount;
        public GameObject forestRoot;
        public float size;
        public float growthRate;
        public CreateForest forestGenerator;



        public float DistanceFrom(Transform target)
        {
            return Vector3.Distance(forestRoot.transform.position, target.position);
        }

        public void CutTree()
        {
            treesCount--;
            if (treesCount <= 0)
            {
                Destroy(forestRoot);
            }
        }
        ~forest()
        {

        }
    }
}
