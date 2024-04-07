using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    #region Singleton
    public static Inventory instance;
    public void Awake() {
        if (instance != null) {
            Debug.LogWarning("More Inventories found!");
        } 
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int spaces = 10;
    public List<Item> items = new List<Item>();
    public bool Add(Item item) {
        if (!item.isDefault) {
           if (items.Count >= spaces) {
                Debug.Log("Not enough space");
                return false;
           }
            items.Add(item);

            if (onItemChangedCallback != null) {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
        //item.Add(item);
    }

    public void Remove(Item item) {
        items.Remove(item);

        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }
    }
}
