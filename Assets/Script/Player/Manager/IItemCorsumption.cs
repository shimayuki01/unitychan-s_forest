using System.Collections.Generic;
public interface IItemConsumption : IBag
{
    void inItem(string itemId, int num);
    void subItemQuantity(string item_id, int num);

    //�o�b�O�ɓ���邱�Ƃ��ł���A�C�e����id�̃��X�g
    string[] getInItemArgumentList();

    //�o�b�O�̒��g
    Dictionary<string, int> getBagSummary();

    //�o�b�O�������ς����ǂ���
    bool isMaxBag();
}