using System;
using System.Collections.Generic;

public class Bag
{
    static int _maxContentsNum = 10;
    Block[] _blockContents = new Block[_maxContentsNum];
    //_summaryContents<id,��>
    Dictionary<String, int> _summaryContents = new Dictionary<String, int>();
    int _oneBlockMax;

    delegate List<Item> getContents();

    //�o�b�N�ɓ�����邩�m�F����֐��̒ǉ�
    bool canIn()
    {
        //���g�������܂��傤
        return true;
    }

    //�w�肵���A�C�e���̌����o�b�O�̒��g��葽�����true��Ԃ�
    bool biggerQuantity(String id, int quantity)
    {
        if(_summaryContents[id] >= quantity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�o�b�O�̒��ɕ�������i���̂��E���j
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


    //�o�b�O����A�C�e�����폜����i�����őf�ނ�������ꍇ�Ȃǁj
    //�A�C�e�����폜�ł��Ȃ������ꍇ��false��Ԃ��B�폜�o������true�B
    public bool deleteItem(String id, int quantity)
    {
        if (_summaryContents.ContainsKey(id))
        { 
            if(biggerQuantity(id,quantity))
            {
                _summaryContents[id] -= quantity;
                return true;
            }

        }
        return false;
    }

    //�o�b�O�̃A�C�e�����O�Ɏ̂Ă�
    delegate Block outItem();


    public bool haveItem(string id)
    {
        //���g��`��
        return true;
    }



    //�u���b�N�i�o�b�O�̒��g�̌`�j�ɕϊ�����
    void summaryToBlock()
    {
        int num = 0;
        foreach(KeyValuePair<String, int> it in _summaryContents)
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