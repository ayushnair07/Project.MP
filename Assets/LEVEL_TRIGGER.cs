using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL_TRIGGER : MonoBehaviour
{
    public GameObject Switch;
    public bool action = false;
    private void Start()
    {
        Switch.SetActive(false);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(action==true)
            {
                Switch.SetActive(false);
                //TerrainChangedFlags lvel script here
            }
        }
    }
}
