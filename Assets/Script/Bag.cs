using System;
using System.Collections.Generic;

public class Bag
{
    static int _maxContentsNum = 10;
    Block[] _blockContents = new Block[_maxContentsNum];
    //_summaryContents<id,数>
    Dictionary<String, int> _summaryContents = new Dictionary<String, int>();
    int _oneBlockMax;

    delegate List<Item> getContents();

    //バックに入れられるか確認する関数の追加
    bool canIn()
    {
        //中身を書きましょう
        return true;
    }

    //指定したアイテムの個数がバッグの中身より多ければtrueを返す
    bool biggerQuantity(String id, int quantity)
    {
        if (_summaryContents[id] >= quantity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //バッグの中に物を入れる（ものを拾う）
    public void inItem(String id, int quantity)
    {
        if (!canIn()) { return; }

        if (_summaryContents.ContainsKey(id))
        {
            _summaryContents[id] += quantity;
        }
        else
        {
            _summaryContents.Add(id, quantity);
        }
    }


    //バッグからアイテムを削除する（料理で素材を消費した場合など）
    //アイテムが削除できなかった場合はfalseを返す。削除出来たらtrue。
    public bool deleteItem(String id, int quantity)
    {
        if (_summaryContents.ContainsKey(id))
        {
            if (biggerQuantity(id, quantity))
            {
                _summaryContents[id] -= quantity;
                return true;
            }

        }
        return false;
    }

    //バッグのアイテムを外に捨てる
    delegate Block outItem();


    public bool haveItem(string id)
    {
        //中身を描く
        return true;
    }



    //ブロック（バッグの中身の形）に変換する
    void summaryToBlock()
    {
        int num = 0;
        foreach (KeyValuePair<String, int> it in _summaryContents)
        {
            int blockNum = it.Value % _oneBlockMax + 1;
            for (int i = 1; i < blockNum; i++)
            {
                _blockContents[num] = new Block(it.Key, _oneBlockMax);
                num++;
            }

            int amari = it.Value - _oneBlockMax * blockNum;
            _blockContents[num] = new Block(it.Key, amari);
            num++;

        }
    }

    int getItemQuantity(string item_id)
    {

        if (!haveItem(item_id)) { return 0; }

        return _summaryContents[item_id];
    }
    public Dictionary<String, int> getBagSummary()
    {
        return _summaryContents;
    }
}

public class Block
{
    String _itemId;
    int _quantity;
    static int _max;

    public Block(String id, int num)
    {
        this._itemId = id;
        this._quantity = num;
    }

    String getItemId() { return this._itemId; }
    int getQuantity() { return this._quantity; }

    delegate void addNum();
    delegate void subNum();
    delegate void maxNum();
    delegate void zeroNum();
}