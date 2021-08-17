using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Color hoverColor;
    private Renderer rend;
    private Color originalColor;

    void Start() {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    void OnMouseExit(){
        rend.material.color = originalColor;
    }
}
