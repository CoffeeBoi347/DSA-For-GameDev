using UnityEngine;

public class Sword : IUsable
{
    string swordName;
    int swordPower;
    public Sword(string _name, int _power)
    {
        swordName = _name;
        swordPower = _power;
    }
    public void Equip()
    {
        Debug.Log($"{swordName} Equipped!");
    }

    public void Dequip()
    {
        Debug.Log($"{swordName} Dequipped!");
    }

    public string GetName()
    {
        return swordName;
    }

    public int GetPower()
    {
        return swordPower;
    }
}

public class Gun : IUsable
{
    string gunName;
    int gunPower;
    public Gun(string _name, int _power)
    {
        gunName = _name;
        gunPower = _power;
    }

    public void Equip()
    {
        Debug.Log($"{gunName} Equipped!");
    }

    public void Dequip()
    {
        Debug.Log($"{gunName} Dequipped!");
    }

    public string GetName()
    {
        return gunName;
    }

    public int GetPower()
    {
        return gunPower;
    }
}

public class WeaponTool : IUsable
{
    string weaponToolName;
    int weaponToolPower;
    public WeaponTool(string _name, int _power)
    {
        weaponToolName = _name;
        weaponToolPower = _power;
    }

    public void Equip()
    {
        Debug.Log($"{weaponToolName} equipped!");
    }

    public void Dequip()
    {
        Debug.Log($"{weaponToolName} Dequipped!");
    }

    public string GetName()
    {
        return weaponToolName;
    }

    public int GetPower()
    {
        return weaponToolPower;
    }
}