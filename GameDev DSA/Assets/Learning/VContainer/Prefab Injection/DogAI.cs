using UnityEngine;
public interface IBasicAI
{
    public void Bark();
    public void Speak();
    public void Attack();
}

public class DogAI : IBasicAI
{
    public void Bark() => Debug.Log("Bow Bow!");
    public void Speak() => Debug.Log("Hello World!");
    public void Attack() => Debug.Log("Attacking!");
}