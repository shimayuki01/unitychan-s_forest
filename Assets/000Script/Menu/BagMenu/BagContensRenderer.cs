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
        DisplayItems(bagPanel);
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
    public void DisplayItems(GameObject bagMenuePanel)
    {
        Dictionary<string, int> bagSummary = playerBag.Value.getBagSummary();
        GameObject itemPanelParent = bagMenuePanel.transform.Find("ItemPanel").gameObject;

        
        //�g�p����A�C�e����擪�ɕ\��
        string useItemId = playerBag.Value.getUseItem();
        GameObject itemPanel;
        //�o�b�N�ɓ����Ă��Ȃ�useItemId���w�肷��Ɖ����\������Ȃ��Ȃ�(�o�O)
        if (useItemId != "")
        {
            // �p�l���̎擾
            itemPanel = itemPanelParent.transform.GetChild(0).gameObject;
            DisplayOneItem(useItemId, bagSummary[useItemId], itemPanel);
            bagSummary.Remove(useItemId);
        }


        int idx = 1;

        foreach (var item in bagSummary)
        {
            string itemId = item.Key;
            int itemNum = item.Value;

            // �p�l���̎擾
            itemPanel = itemPanelParent.transform.GetChild(idx).gameObject;

            DisplayOneItem(itemId, itemNum, itemPanel);

           idx++;
        }
    }

    private void DisplayOneItem(string itemId, int itemNum, GameObject itemPanel)
    {     
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
        panelText.text = itemNum.ToString();
    }
}
