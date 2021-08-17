using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject tankToBuild;

    void Awake() {
        if(instance != null) return;
        instance = this;
    }

    public void SetTankToBuild(GameObject tankObj) {
        tankToBuild = tankObj;
    }

    public GameObject GetTankToBuild() {
        return tankToBuild;
    }
}
