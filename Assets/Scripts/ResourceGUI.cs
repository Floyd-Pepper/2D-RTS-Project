using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ResourceGUI {
	
	public static void SetWoodAmount (int wood) {
        var woodAmountText = GameObject.Find("WoodAmountText").GetComponent<Text>();
        woodAmountText.text = "Wood : " + wood;
    }

    public static void SetGoldAmount(int gold)
    {
        var goldAmountText = GameObject.Find("GoldAmountText").GetComponent<Text>();
        goldAmountText.text = "Gold : " + gold;
    }
}
