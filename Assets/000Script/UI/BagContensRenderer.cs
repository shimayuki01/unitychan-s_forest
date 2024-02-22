using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagContensRenderer : MonoBehaviour
{
    public void DisplayItems(GameObject bagMenuePanel, Dictionary<string, int> bagSummary)
    {
        //GameObject temp = bagMenuePanel.transform.Find("BagPanel").gameObject;
        GameObject itemPanelParent = bagMenuePanel.transform.Find("ItemPanel").gameObject;
        int idx = 0;
        foreach (var item in bagSummary)
        {
            GameObject itemPanel = itemPanelParent.transform.GetChild(idx).gameObject;
            Text panelText = itemPanel.GetComponentInChildren<Text>();
            panelText.text = item.Value.ToString();
            //Debug.Log("=============== UIŠm”F" + item.Value.ToString());
            idx++;

        }
    }
}
