using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AbilityManager<T> where T : IAbility
{
    public List<string> abilityHolder = new List<string>();
    private List<T> abilityComponentsHolder = new List<T>();
    public void AddAbility(T ability)
    {
        string itemName = ability.GetItemName;
        if (!abilityHolder.Contains(itemName))
        {
            abilityHolder.Add(itemName);
            abilityComponentsHolder.Add(ability);
            SaveItem();
        }
    }

    public void RemoveAbility(T ability)
    {
        string itemName = ability.GetItemName;
        if(abilityHolder.Contains(itemName))
        {
            abilityHolder.Remove(itemName);
            abilityComponentsHolder.Remove(ability);
            SaveItem();
        }
    }

    public void LoadAbilities()
    {
        string path = Application.persistentDataPath + "/rewardsHolderLoader.json";

        if (!File.Exists(path))
        {
            File.Create(path);
            LoadAbilitiesIfPathExists();
        }

        else
        {
            LoadAbilitiesIfPathExists();
        }
    }

    private void LoadAbilitiesIfPathExists()
    {
        string path = Application.persistentDataPath + "/rewardsHolderLoader.json";
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            Debug.Log("Reading all lines...");
            foreach (string line in lines)
            {
                Debug.Log(line);
            }
        }
    }

    private void SaveItem()
    {
        string path = Application.persistentDataPath + "/rewardsHolderLoader.json";
        File.WriteAllLines(path, abilityHolder);
    }

    public void SortDescendingByCooldown()
    {
        int maxNo = 0;
        foreach(var item in abilityComponentsHolder)
        {
            int itemCooldown = item.GetCooldownTime;
            if(itemCooldown > maxNo)
            {
                maxNo = itemCooldown;
            }
        }
        List<int> abilitiesCooldownHolder = new List<int>();
        int[] maxNoArray = new int[maxNo + 1];

        for(int i = 0; i < abilityComponentsHolder.Count; i++)
        {
            maxNoArray[abilityComponentsHolder[i].GetCooldownTime]++;
            abilitiesCooldownHolder.Add(abilityComponentsHolder[i].GetCooldownTime);
        }


        int index = 0;
        Debug.Log("Loading abilities from their descending cooldown time: ");
        for(int i = maxNo; i >= 0; i--)
        {
            if (maxNoArray[i] > 0)
            {
                abilitiesCooldownHolder[index] = i;
                Debug.Log(abilitiesCooldownHolder[index]);
                index++;
            }
        }
    }

    public void LoadByPriorities()
    {
        foreach(var item in abilityComponentsHolder)
        {
            Debug.Log($"{item.GetItemName} : {item.GetPriority}");
        }
    }

    public void UseAllAbilites()
    {
        foreach(var item in abilityComponentsHolder)
        {
            item.Action();
        }
    }
}