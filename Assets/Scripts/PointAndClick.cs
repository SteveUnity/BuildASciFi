using UnityEngine;

public class PointAndClick : MonoBehaviour {

    public static bool cast = false;
    //public static bool cast { get { return _cast; } set { _cast = value; terrainMouseLocation = new Vector3(100, -100, 100); } }
    private static Vector3 terrainMouseLocation = Vector3.zero;
    public static Vector3 TerrainMouseLocation {
        get
        {
            return terrainMouseLocation;
        }
    }
    private static Transform firstHitTarget = null;
    public static Transform FirstHitTarget
    {
        get
        {
            return firstHitTarget;
        }
    }

	// Use this for initialization
	void Start () {
	}
    void Update()
    {
        if (cast)
            GetMouseClickLoc();
    }
	
	// Update is called once per frame
	static void GetMouseClickLoc () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hit;
        hit = Physics.RaycastAll(ray, 1000f);
        if (hit.Length>0)
        {
            firstHitTarget = hit[hit.Length - 1].transform;
            foreach (var item in hit)
            {
                if (item.transform.gameObject.layer == 8)
                {
                    terrainMouseLocation = item.point;
                    break;
                }
            }
        }
    }
}
