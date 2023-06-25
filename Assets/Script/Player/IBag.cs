using System;
using System.Collections.Generic;
interface IBag
{
    Dictionary<String, int> getBagSummary();
    void inItem(String id, int quantity);
    void outItem(String id, int quantity);
}