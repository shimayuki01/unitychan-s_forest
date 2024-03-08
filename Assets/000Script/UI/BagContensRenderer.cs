using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagContensRenderer : MonoBehaviour
{
    public void InitItemPanel(GameObject bagMenuePanel)
    {
        GameObject itemPanelParent = bagMenuePanel.transform.Find("ItemPanel").gameObject;
        for (int i = 0; i < 9; i++)
        {
            GameObject itemPanel = itemPanelParent.transform.GetChild(i).gameObject;
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            panelImage.sprite = null;
            panelImage.color = new Color(0, 0, 0, 0);
        }

    }
    public void DisplayItems(GameObject bagMenuePanel, Dictionary<string, int> bagSummary)
    {

        GameObject itemPanelParent = bagMenuePanel.transform.Find("ItemPanel").gameObject;
        int idx = 0;
        foreach (var item in bagSummary)
        {
            string item_id = item.Key;
            int item_num = item.Value;

            // �p�l���̎擾
            GameObject itemPanel = itemPanelParent.transform.GetChild(idx).gameObject;


            // �A�C�e���摜�̕\��
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            // �A�C�e���摜�̎擾
            Sprite itemImage = GameData.instance.getItemImage(item_id);
            panelImage.sprite = Instantiate(itemImage);
            // �A�C�e���̓����x��255�ɂ��ĕ\������
            panelImage.color = new Color(255, 255, 255, 255);

            // �A�C�e�����̕\��
            Text panelText = itemPanel.GetComponentInChildren<Text>();
            panelText.text = item_num.ToString();

            idx++;
        }
    }
}
