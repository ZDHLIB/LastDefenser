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

        BuildManager.instance.Build(this);
    }

    public void SetTank(GameObject obj) {
        tank = obj;
    }

    public Vector3 GetPosition() {
        return transform.position + positionOffset;
    }

    public Quaternion GetRotation() {
        return transform.rotation;
    }
}
