using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class camNext : MonoBehaviour
{
    public GameObject teleporter;
    public GameObject player;
    public GameObject cam;
    private bool isTeleported;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (scoretext.text == "Score: 4")
     {
       Teleport() ;
     }  
    }
    void Teleport(){
            isTeleported = true;
            cam.transform.position = teleporter.transform.position;
        }
}
