using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
        }

        instance = this;
    }
    #endregion

    public int maxSpace = 20;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefault)
        {
            if(items.Count >= maxSpace) 
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
        }
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
    }


}
