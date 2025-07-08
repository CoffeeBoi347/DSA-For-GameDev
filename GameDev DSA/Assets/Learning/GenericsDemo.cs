using System.Collections.Generic;
using UnityEngine;

public class GenericsDemo : MonoBehaviour
{
    public void Start()
    {
        GenericsClass<string> stringGenerics = new GenericsClass<string>();
        List<string> stringHolder = new List<string>();
        List<string> displayItems = new List<string> { "Music", "Games", "Apps", "Websites" };
        foreach(var item in displayItems)
        {
            stringGenerics.PickupItem(item, stringHolder);
        }

        stringGenerics.ShowItems(stringHolder);
        stringGenerics.DropItem("Music", stringHolder);
        stringGenerics.ShowItems(stringHolder);

        GenericsClass<int> intGenerics = new GenericsClass<int>();
        List<int> integersHolder = new List<int>();
        List<int> displayListItems = new List<int> { 1, 2, 3, 4 };
        foreach(int itemLst in displayListItems)
        {
            intGenerics.PickupItem(itemLst, integersHolder);
        }
        intGenerics.ShowItems(integersHolder);
        intGenerics.DropItem(1, integersHolder);
        intGenerics.ShowItems(integersHolder);
    }
}