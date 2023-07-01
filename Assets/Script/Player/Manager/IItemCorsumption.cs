using System.Collections.Generic;
public interface IItemConsumption : IBag
{
    void inItem(string itemId, int num);
    void subItemQuantity(string item_id, int num);

    //バッグに入れることができるアイテムのidのリスト
    string[] getInItemArgumentList();

    //バッグの中身
    Dictionary<string, int> getBagSummary();

    //バッグがいっぱいかどうか
    bool isMaxBag();
}