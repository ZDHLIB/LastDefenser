using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public GameObject tank1Prefab;

    void Awake() {
        if(instance != null) return;
        instance = this;
    }

    public void PurchaseTank1(){
        Debug.Log("PurchaseTank1");
        BuildManager.instance.SetTankToBuild(tank1Prefab);
    }
}
