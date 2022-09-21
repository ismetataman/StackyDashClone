using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishColorChange : MonoBehaviour
{
    public UIManager uimanager;
    public Material[] allMaterials;
    public GameObject[] allPlatforms;
    public GameObject[] sidePlatforms;
    private int colorCounter = 0;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Color"))
        {
            allPlatforms[colorCounter].gameObject.GetComponent<MeshRenderer>().material = allMaterials[colorCounter];
            sidePlatforms[colorCounter].gameObject.GetComponent<MeshRenderer>().material = allMaterials[colorCounter];
            colorCounter ++;
        }    
    }
}
