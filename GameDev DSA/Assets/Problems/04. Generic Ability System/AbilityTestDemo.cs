using UnityEngine;
public class AbilityTestDemo : MonoBehaviour
{
    private void Start()
    {
        AbilityManager<IAbility> abilityManager = new AbilityManager<IAbility>();
        abilityManager.AddAbility(new FireballAbility());
        abilityManager.AddAbility(new ShieldAbility());
        abilityManager.AddAbility(new DefaultAbility());
        abilityManager.AddAbility(new HealAbility());

        abilityManager.LoadAbilities();
        abilityManager.UseAllAbilites();
        abilityManager.SortDescendingByCooldown();
        abilityManager.LoadByPriorities();
        abilityManager.RemoveAbility(new DefaultAbility());
        abilityManager.LoadAbilities();
    }
}