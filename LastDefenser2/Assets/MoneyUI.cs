using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyLeftText;

    // Update is called once per frame
    void Update()
    {
        moneyLeftText.text = string.Format("{0}", PlayerStatusManager.Money);
    }
}
