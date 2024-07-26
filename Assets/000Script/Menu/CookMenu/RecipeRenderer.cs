using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeRenderer : MonoBehaviour
{
    private CookItem[] _recipeArray;
    private void Start()
    {
        _recipeArray = GameData.instance.getCookItemDataArray();
    }

    public void PasteRecipe(GameObject cookPanel, Player player)
    {
        Debug.Log("Open Cook Menu");
        // �p�l���ɕ\�����Ă�����̂���ɂ���
        InitItemPanel(cookPanel);
        List<CookItem> cookableItemList = GenerateCookableItemList(player.getBagSummary());
        // �p�l���Ɍ��ݍ쐬�ł��闿����\������
        DisplayItems(cookPanel, cookableItemList, player);
    }
    public void InitItemPanel(GameObject cookPanel)
    {
        GameObject itemPanelParent = cookPanel.transform.Find("ItemPanel").gameObject;
        for (int i = 0; i < 9; i++)
        {
            GameObject itemPanel = itemPanelParent.transform.GetChild(i).gameObject;
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            panelImage.sprite = null;
            panelImage.color = new Color(0, 0, 0, 0);
        }

    }
    public void DisplayItems(GameObject cookPanel, List<CookItem> recipeArray, Player player)
    {

        GameObject itemPanelParent = cookPanel.transform.Find("ItemPanel").gameObject;
        int idx = 0;
        Debug.Log("���V�s��\���I");

        foreach (CookItem recipe in recipeArray)
        {
            Debug.Log("���V�s��\��:" + idx);
            string itemId = recipe.id;

            // �p�l���̎擾
            GameObject itemPanel = itemPanelParent.transform.GetChild(idx).gameObject;

            // �p�l���̃X�N���v�g��itemId����������
            itemPanel.GetComponent<CookItemPanel>().setItemId(itemId);

            // �A�C�e���摜�̕\��
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            // �A�C�e���摜�̎擾
            Sprite itemImage = GameData.instance.getItemImage(itemId);
            panelImage.sprite = Instantiate(itemImage);
            // �A�C�e���̓����x��255�ɂ��ĕ\������
            panelImage.color = new Color(255, 255, 255, 255);


            idx++;
        }


        // �쐬�{�^���Ƀv���C���[����������B
        CookExeButton.instance.player = player;
    }

    // �쐬�\�ȗ����̃��X�g���쐬����
    List<CookItem> GenerateCookableItemList(Dictionary<string, int> playerBagSummary)
    {
        List<CookItem> cookableItemList = new List<CookItem>();
        foreach (CookItem recipe in _recipeArray)
        {
            bool cookable = true;
            // �e�f�ނ̌����o�b�O�̒��g��葽�������肷��
            foreach (Sozai need_sozai in recipe.sozai)
            {
                
                if (!biggerQuantity(playerBagSummary, need_sozai.id, need_sozai.num))
                {
                    cookable = false;
                }
            }

            // �����\�Ȃ��̂����X�g�ɒǉ�����
            if (cookable)
            {
                cookableItemList.Add(recipe);
            }

        }

        return cookableItemList;
    }

    bool biggerQuantity(Dictionary<string, int> playerBagSummary, string id, int quantity)
    {
        bool retval = false;
        if (playerBagSummary.ContainsKey(id))
        {
            if (playerBagSummary[id] >= quantity)
            {
                retval =  true;
            }
        }

        return retval;

    }
}
