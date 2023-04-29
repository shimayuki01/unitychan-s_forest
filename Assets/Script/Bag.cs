using System;
using System.Collections.Generic;

public class Bag
{
    static int _maxContentsNum = 10;
    Block[] _blockContents = new Block[_maxContentsNum];
    Dictionary<Item, int> _summaryContents = new Dictionary<Item, int>();
    int _oneBlockMax;

    delegate List<Item> getContents();

    //バックに入れられるか確認する関数の追加
    bool canIn()
    {
        //中身を書きましょう
        return true;
    }

    //バッグの中に物を入れる（ものを拾う）
    public void inItem(Item item, int num)
    {
        if (!canIn()) { return; }
        if (_summaryContents.ContainsKey(item))
        {
            _summaryContents[item] += num;
        }
        else
        {
            _summaryContents.Add(item, num);
        }
    }
    delegate Block outItem();
    public bool haveItem(int item_id)
    {
        //中身を描く
        return true;
    }
    int getItemQuantity(int item_id)
    {

        if (!haveItem(item_id)) {return 0;}

        return 1;


    }


    //ブロック（バッグの中身の形）に変換する
    void summaryToBlock()
    {
        int num = 0;
        foreach(KeyValuePair<Item, int> it in _summaryContents)
        {
            int blockNum = it.Value % _oneBlockMax +1;
            for(int i = 1; i < blockNum; i++)
            {
                _blockContents[num] = new Block(it.Key, _oneBlockMax);
                num++;
            }

            int amari = it.Value - _oneBlockMax * blockNum;
            _blockContents[num] = new Block(it.Key, amari);
            num++;

        }
    }
    public Dictionary<Item, int> getSummary()
    { 
        return _summaryContents;
    }
}

public class Block
{
    Item _item = new Item();
    int _num;
    static int _max;

    public Block(Item it, int num) 
    {
        this._item = it;
        this._num = num;
    }

    Item getItem() { return this._item; }
    int getNum() { return this._num; }

    delegate void addNum();
    delegate void subNum();
    delegate void maxNum();
    delegate void zeroNum();
}