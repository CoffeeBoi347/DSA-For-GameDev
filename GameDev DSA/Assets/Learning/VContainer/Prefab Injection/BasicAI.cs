using UnityEngine;
using VContainer;

public class BasicAI : MonoBehaviour
{
    private IBasicAI ai;

    [Inject]
    public void Construct(IBasicAI _ai)
    {
        this.ai = _ai;
    }

    private void Update()
    {
        if (this.ai != null)
        {
            ai.Bark();
            ai.Speak();
            ai.Attack();
        }
    }
}