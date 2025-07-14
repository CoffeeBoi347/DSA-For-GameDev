using NUnit.Framework;
using UnityEngine;

public class EditModeTestScript
{
    [Test]
    public void TestAbilities()
    {
        AbilitySO fireball = ScriptableObject.CreateInstance<AbilitySO>();
        fireball.abilityName = "Fireball";
        fireball.cooldownTime = 2;

        AbilitySO thunder = ScriptableObject.CreateInstance<AbilitySO>();
        thunder.abilityName = "Thunder";
        thunder.cooldownTime = 5;

        CooldownSystem<AbilitySO> cooldownSystem = new CooldownSystem<AbilitySO>();

        cooldownSystem.AddAbility(fireball);
        cooldownSystem.AddAbility(thunder);
        cooldownSystem.SortByCooldownTime();
        cooldownSystem.UseAllAbilities();

        cooldownSystem.UseAbility(fireball);
    }

    [Test]
    public void TestAbilities2()
    {
        AbilitySO fireball = ScriptableObject.CreateInstance<AbilitySO>();
        fireball.abilityName = "Fireball";
        fireball.cooldownTime = 2;

        AbilitySO thunder = ScriptableObject.CreateInstance<AbilitySO>();
        thunder.abilityName = "Thunder";
        thunder.cooldownTime = 5;

        CooldownSystem<AbilitySO> cooldownSystem = new CooldownSystem<AbilitySO>();

        cooldownSystem.AddAbility(fireball);
        cooldownSystem.AddAbility(thunder);
        cooldownSystem.SortByCooldownTime();
        cooldownSystem.UseAllAbilities();

        cooldownSystem.UseAbility(fireball);
        Assert.AreEqual(2, cooldownSystem.abilityHolder.Count);
    }

}
