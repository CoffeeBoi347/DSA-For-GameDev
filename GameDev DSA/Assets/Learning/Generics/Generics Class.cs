using System.Collections.Generic;
using UnityEngine;

public class GenericsClass<T>
{
    public T item; 

    public void PickupItem(T newItem, List<T> holder)
    {
        item = newItem;
        Debug.Log($"ItemPicker{typeof(T)}: {newItem.ToString()}");
        holder.Add(newItem);
    }

    public void ShowItems(List<T> holder)
    {
        Debug.Log("Showing inventory!");

        foreach(T item in holder)
        {
            Debug.Log(item);
        }
    }

    public void DropItem(T newItem, List<T> holder)
    {
        holder.Remove(newItem);
        Debug.Log($"ItemRemover{typeof(T)}: {newItem.ToString()}");
    }
}