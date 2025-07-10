using UnityEngine;

public interface IAbility
{
    string GetItemName {  get; }
    int GetCooldownTime { get; }
    int GetPriority {  get; }
    void Action();
}

public class FireballAbility : IAbility
{
    public string GetItemName => "Fireball";
    public int GetCooldownTime => 5;
    public int GetPriority => 0;

    public void Action()
    {
        Debug.Log("[FireballAbility] Used a fireball!");
    }
}

public class HealAbility : IAbility
{
    public string GetItemName => "Healing";
    public int GetCooldownTime => 10;
    public int GetPriority => 1;

    public void Action()
    {
        Debug.Log("[HealAbility] Used healing ability!");
    }
}

public class ShieldAbility : IAbility
{
    public string GetItemName => "Shield";
    public int GetCooldownTime => 20;
    public int GetPriority => 2;

    public void Action()
    {
        Debug.Log("[ShieldAbility]: Used Shield Ability!");
    }
}

public class DefaultAbility : IAbility
{
    public string GetItemName => "Default";
    public int GetCooldownTime => 2;
    public int GetPriority => 3;

    public void Action()
    {
        Debug.Log("[DefaultAbility]: Used default ability!");
    }
}