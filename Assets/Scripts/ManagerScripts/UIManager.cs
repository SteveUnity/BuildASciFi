using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtGold;
    public Text TxtGold { get { return txtGold; } }

    [SerializeField]
    private Text txtWood;
    public Text TxtWood { get { return txtWood; } }

    [SerializeField]
    private Text txtFood;
    public Text TxtFood { get { return txtFood; } }


    public void Start()
    {
        
    }

}
