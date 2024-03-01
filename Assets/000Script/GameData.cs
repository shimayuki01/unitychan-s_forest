using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading;
using System.Threading.Tasks;

public class GameData : MonoBehaviour , ICookItemSozaiAcquisition
{ 
    Item[] itemDataArray;
    CookItem[] cookItemDataArray;
    ArrayList allItemDataArray;
    Dictionary<string, Item> id2Item;
    Dictionary<string, CookItem> id2CookItem;
    Dictionary<string, CookItem> cookItemName2item;
    Dictionary<string, Sprite> id2ItemImage;


    // Start is called before the first frame update
    void Awake()
    {
        //jsonからデータの読み込み
        //レシピ　= [Item 木,Item 石]
        itemDataArray = new JsonReaderFromResourcesFolder().GetItemDataArray().gameItems;
        //レシピ　= [CookItem カレー,CookItem 肉じゃが]
        cookItemDataArray = new JsonReaderFromResourcesFolder().GetRecipe().gameItems;

        allItemDataArray = new ArrayList(itemDataArray);
        allItemDataArray.AddRange(cookItemDataArray);



        //idとitemの辞書

        //itemの辞書
        id2Item = new Dictionary<string, Item>();
        //CookItemの辞書
        cookItemName2item = new Dictionary<string, CookItem>();
        id2CookItem = new Dictionary<string, CookItem>();

        foreach (Item item in itemDataArray)
        {
            id2Item.Add(item.id, item);
        }

        foreach (CookItem item in cookItemDataArray)
        {
            cookItemName2item.Add(item.name, item);
        }
        foreach (CookItem item in cookItemDataArray)
        {
            id2CookItem.Add(item.id, item);
        }



    }

    async Task Start()
    {
        foreach (Item item in allItemDataArray)
        {
            Debug.Log(item.id);
            Task<Sprite> Image;

            //handle = Addressables.LoadAssetAsync<Sprite>("Assets/050image/food_curryruce.png");
            Image = fetchImage(item.imgFileName);

            await Task.WhenAll(Image);
            id2ItemImage.Add(item.id, Image.Result);
        }
    }




    async Task<Sprite> fetchImage(string imgFileName)
    {
        AsyncOperationHandle<Sprite> handle;

        handle = Addressables.LoadAssetAsync<Sprite>(imgFileName);

        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
            Debug.Log("成功");

        return handle.Result;
    }

    public Item getItem(string item_id)
    {
        return id2Item[item_id];
    }
    public CookItem getRecipeFromName(string cookItem_name)
    {
        return cookItemName2item[cookItem_name];
    }

    public CookItem getRecipe(string cookItem_id)
    {
        return id2CookItem[cookItem_id];
    }

    public Sozai[] getCookItemSozai(string cookItem_id)
    {
        return id2CookItem[cookItem_id].sozai;
    }

    public CookItem[] getCookItemDataArray()
    {
        return cookItemDataArray;
    }
}
