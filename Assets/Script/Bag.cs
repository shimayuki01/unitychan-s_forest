using System;
using System.Collections.Generic;

public class Bag : IItemConsumption
{
    static int MAX_CONTENTS_NUM = 10;
    Block[] _blockContents = new Block[MAX_CONTENTS_NUM];
    //_summaryContents<id,数>
    Dictionary<String, int> _summaryContents = new Dictionary<String, int>();
    int _oneBlockMax;

    delegate List<Item> getContents();

    //バックに入れられるか確認する関数の追加
    bool canIn(string itemId)
    {
        if (!isMaxBag())//bagがmaxじゃなかったらtrue
            return true;

        return createInItemArgumentList().Contains(itemId); //bagに入れれるアイテムリストに入っていればtrueを返す
    }

    //指定したアイテムの個数がバッグの中身より多ければtrueを返す
    bool biggerQuantity(string id, int quantity)
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
    public void inItem(string id, int quantity)
    {
        if (!canIn(id)) 
        {
            //入れなかったらメッセージを入れる関数の作成
            return; 
        }

        if (_summaryContents.ContainsKey(id))
        {
            _summaryContents[id] += quantity;
        }
        else
        {
            _summaryContents.Add(id, quantity);
        }
    }

    //バッグのアイテムを減らす
    public void subItemQuantity(string id, int quantity)
    {
        _summaryContents[id] -= quantity;
    }

    public bool haveItem(string id)
    {
        //中身を描く
        return true;
    }

    public bool isMaxBag()
    {
        if (_blockContents[MAX_CONTENTS_NUM - 1] == null) //bagがmaxじゃなければ(_blockContentsに最後まで入っていない)false
            return false;

        return true; //そうでなければtrue
    }

    public List<string> createInItemArgumentList()
    {
        List<string> InItemArgumentList = new List<string>();
        foreach(Block block in _blockContents)
        {
            if(block.getQuantity() < block.getBLOCK_MAX())
            {
                InItemArgumentList.Add(block.getItemId());
            }
        }

        return InItemArgumentList;
    }


    //ブロック（バッグの中身の形）に変換する
    void summaryToBlock()
    {
        Array.Clear(_blockContents, 0, _blockContents.Length); //配列の初期化
                                                               
        int index = 0;
        foreach (KeyValuePair<String, int> it in _summaryContents)
        {
            int blockNum = it.Value / _oneBlockMax;
            for (int i = 0; i < blockNum; i++)
            {
                _blockContents[index] = new Block(it.Key, _oneBlockMax);
                index++;
            }

            //余りが存在するなら余りの分を追加で入れる
            if (it.Value % _oneBlockMax != 0)
            {
                _blockContents[index] = new Block(it.Key, it.Value % _oneBlockMax);
                index++;
            }

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
    static int BLOCK_MAX = 10;//一ブロックの最大の値

    public Block(String id, int num )
    {
        this._itemId = id;
        this._quantity = num;
    }

    public String getItemId() { return this._itemId; }
    public int getQuantity() { return this._quantity; }

    public int getBLOCK_MAX() { return BLOCK_MAX; }

    //public void setBLOCK_MAX(int max)
    //{
    //    BLOCK_MAX = max;
    //}


    delegate void addNum();
    delegate void subNum();
    delegate void maxNum();
    delegate void zeroNum();
}