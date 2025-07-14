using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Abilities/Ability", order = 1)]
public class AbilitySO : ScriptableObject, ICooldown
{
    public string abilityName;
    public float cooldownTime;
    private float cooldownSeconds;

    public bool IsOnCooldown => Time.time < cooldownSeconds;

    public void TriggerCooldown()
    {
        if (IsOnCooldown)
        {
            Debug.Log($"{abilityName} is on cooldown. Wait for {GetRemainingTime()} seconds.");
            return;
        }

        else
        {
            Debug.Log($"Triggered {abilityName}");
            cooldownSeconds = Time.time + cooldownTime;
        }
    }

    public float GetRemainingTime()
    {
        return Mathf.Max(0, cooldownSeconds - Time.time);
    }
}