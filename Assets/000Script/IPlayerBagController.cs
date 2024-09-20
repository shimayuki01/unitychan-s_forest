using System.Collections.Generic;

public interface IPlayerBagController
{
    public Dictionary<string, int> getBagSummary();
    public string getUseItem();
    public void setUseItem();
}
