using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour{

    public static float Money;
    public float startMoney = 400;
    

    void Start() {
        Money = startMoney;
    }

    public static bool AddMoney(float val) {
        Money += val;
        return true;
    }

    public static bool SubMoney(float val) {
        if(val > Money) return false;
        Money -= val;
        return true;
    }    
}
