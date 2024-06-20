using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TNRD;

public class BagContensRenderer : MonoBehaviour
{
    public SerializableInterface<IPlayerBagController> playerBag;

    public void OpenBagPanel(GameObject bagPanel)
    {
        // �p�l���ɕ\�����Ă�����̂���ɂ���
        InitItemPanel(bagPanel);
        // �p�l���Ɍ��ݎ擾���Ă���A�C�e����\������
        DisplayItems(bagPanel, playerBag.Value.getBagSummary());
    }
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
            string itemId = item.Key;
            int item_num = item.Value;


            // �p�l���̎擾
            GameObject itemPanel = itemPanelParent.transform.GetChild(idx).gameObject;

            // �p�l���̃X�N���v�g��itemId����������
            itemPanel.GetComponent<BagItemPanel>().setItemId(itemId);

            // �A�C�e���摜�̕\��
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            // �A�C�e���摜�̎擾
            Sprite itemImage = GameData.instance.getItemImage(itemId);
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