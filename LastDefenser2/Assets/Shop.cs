using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
public class Shop : MonoBehaviour
{
    public static Shop instance;
    public WeaponModel tankModel;

    void Awake() {
        if(instance != null) return;
        instance = this;
    }

    public void PurchaseTank1(){
        Debug.Log("PurchaseTank1");
        if(PlayerStatusManager.Money < tankModel.price) {
            Debug.Log("Can not build tank1. Do not have enough money.");
        } else {
            BuildManager.instance.SetWeaponModelToBuild(tankModel);
        }
        
    }
}
