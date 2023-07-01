using System.Collections;
using System.Collections.Generic;


//料理が
public class Cook : IManager
{
    IItemConsumption _bag;
    ICookItemSozaiAcquisition _cookItemSozaiAcquisition;


    public Cook(ICookItemSozaiAcquisition cookItemSozaiAcquisition)
    {
        _bag = new Bag();
        _cookItemSozaiAcquisition = cookItemSozaiAcquisition;

    }


    //バックの材料を消費して料理をバックに追加
    public void doCook(string cookItem_id)
    {
        //レシピの情報をひぱってくる
        Sozai[] sozais = _cookItemSozaiAcquisition.getCookItemSozai(cookItem_id);

        //バックから素材を引く(個数確認はcanCookで行う)
        foreach (Sozai need_sozai in sozais)
        {
            _bag.subItemQuantity(need_sozai.id, need_sozai.num);
        }

        //現状はまとめて調理できないので調理後のcook_itemは一つ
        _bag.inItem(cookItem_id, 1);

    }

    public void pickUpItem(string item_id, int quantity)
    {
        List<string> inItemArgumentList = new List<string>(_bag.getInItemArgumentList());
        if (_bag.isMaxBag() && !inItemArgumentList.Contains(item_id)) {
            return;
        }
        _bag.inItem(item_id, quantity);
    }
}
