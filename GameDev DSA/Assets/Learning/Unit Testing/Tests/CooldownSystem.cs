using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class CooldownSystem<T> where T : AbilitySO, ICooldown
{
    public List<T> abilityHolder = new List<T>();
    private List<string> abilityHolderNames = new List<string>();
    private List<int> abilityHolderCountdownValues = new List<int>();   

    public void AddAbility(T abilityToAdd)
    {
        abilityHolder.Add(abilityToAdd);
        abilityHolderNames.Add(abilityToAdd.abilityName);
        abilityHolderCountdownValues.Add((int)abilityToAdd.cooldownTime);
        Debug.Log($"Added {abilityToAdd.abilityName}");
    }

    public void RemoveAbility(T abilityToRemove)
    {
        abilityHolder.Remove(abilityToRemove);
        abilityHolderNames.Remove(abilityToRemove.abilityName);
        abilityHolderCountdownValues.Remove((int)abilityToRemove.cooldownTime);
        Debug.Log($"Removed {abilityToRemove.abilityName}");
    }

    public void UseAllAbilities()
    {
        if (abilityHolder.Count < 0) return;

        foreach(T ability in abilityHolder)
        {
            ability.TriggerCooldown();
        }
    }

    public void UseAbility(T ability)
    {
        ability.TriggerCooldown();
    }

    public void SaveAllAbilities()
    {
        string path = Application.persistentDataPath + "/abilityCooldownHolder.json";
        File.WriteAllLines(path, abilityHolderNames);
    }

    public void LoadAllAbilities()
    {
        string path = Application.persistentDataPath + "/abilityCooldownHolder.json";
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach(var line in lines)
            {
                Debug.Log(line);
            }
        }
    }

    public void SortByCooldownTime()
    {
        float maxNo = 0;

        foreach(T abilityCountdown in abilityHolder)
        {
            float getCooldown = abilityCountdown.cooldownTime;
            if(getCooldown > maxNo)
            {
                maxNo = getCooldown;
            }
        }

        int maxNoInt = (int)maxNo;
        int[] maxArrays = new int[maxNoInt + 1];

        for(int i = 0; i < abilityHolderCountdownValues.Count; i++)
        {
            maxArrays[abilityHolderCountdownValues[i]]++;
        }

        int index = 0;
        for(int i = 0; i < maxArrays.Length; i++)
        {
            if (maxArrays[index] > 0)
            {
                Debug.Log(i);
                index++;
            }
        }
    }
}

public interface ICooldown
{
    bool IsOnCooldown { get; }
    void TriggerCooldown();
    float GetRemainingTime();
}