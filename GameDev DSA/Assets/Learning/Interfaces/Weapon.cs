using System.Collections.Generic;
using UnityEngine;
public class Weapon<T> where T : IUsable
{
    public List<T> weaponHolder;
    public string weaponName;
    public int weaponPower;
    private T component;

    public Weapon(T _usableComponent)
    {
        weaponName = _usableComponent.GetName();
        weaponPower = _usableComponent.GetPower();
        component = _usableComponent;
        weaponHolder = new List<T>();
    }

    public void Equip()
    {
        component.Equip();
        AddWeapon(component); 
        Debug.Log($"Equipping {weaponName}");
    }

    public void Dequip()
    {
        component.Dequip();
        weaponHolder.Remove(component);
        Debug.Log($"Dequipped {weaponName}");
    }

    public void AddWeapon(T item)
    {
        if (!weaponHolder.Contains(item))
        {
            weaponHolder.Add(item);
        }
    }

    public void ViewAllItems()
    {
        int index = 1;
        foreach (var weapon in weaponHolder)
        {
            Debug.Log($"Weapon {index}: {weapon.GetName()} (Power: {weapon.GetPower()})");
            index++;
        }
    }
}
