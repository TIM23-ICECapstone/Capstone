using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reversebutton : MonoBehaviour
{
    public static Reversebutton Instance { get; set; }
    public GameObject reverseOff;
    public GameObject reverseOn;
    public bool reverses;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if(MainMenuManager.Instance.isReverseOn == true){
            reverseOff.SetActive(false);
            reverseOn.SetActive(true);
            reverses = true;
        }
        else{
            reverseOff.SetActive(true);
            reverseOn.SetActive(false);
            reverses = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
