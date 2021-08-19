using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;    

    private WeaponModel weaponModelToBuild;

    void Awake() {
        if(instance != null) return;
        instance = this;
    }

    public void SetWeaponModelToBuild(WeaponModel weaponModel) {
        weaponModelToBuild = weaponModel;
    }

    public void Build(Node node) {
        if(weaponModelToBuild == null) return;

        PlayerStatusManager.SubMoney(weaponModelToBuild.price);

        GameObject builtTank = (GameObject) Instantiate(weaponModelToBuild.weaponPrefab, node.GetPosition(), node.GetRotation());   

        node.SetTank(builtTank);

        SetWeaponModelToBuild(null);
    }
}
