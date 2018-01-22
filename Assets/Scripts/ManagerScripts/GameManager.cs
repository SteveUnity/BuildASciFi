using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager current;
    public ResourcesManager Resources;
    public BuildingsManager buildingsManager;
    public BuildManager buildManager;
    public UIManager UIManager;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else if (current != this)
            Destroy(gameObject);

        UIManager = GetComponent<UIManager>();
        Resources = GetComponent<ResourcesManager>();
        buildingsManager = GetComponent<BuildingsManager>();
        buildManager = GetComponent<BuildManager>();
    }

    // Use this for initialization
    void Start () {
       
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
