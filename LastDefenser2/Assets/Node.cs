using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;
    private GameObject tank;

    public Color highlightColor;
    public Vector3 positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void OnMouseEnter() {
        rend.material.color = highlightColor;
    }

    void OnMouseExit() {
        rend.material.color = originalColor;
    }

    void OnMouseDown() {
        if(tank != null) {
            Debug.Log("Can not build there!");
            return;
        }

        GameObject tankToBuild = BuildManager.instance.GetTankToBuild();

        if(tankToBuild == null) return;

        Instantiate(tankToBuild, transform.position + positionOffset, transform.rotation);   

        BuildManager.instance.SetTankToBuild(null);
    }
}
