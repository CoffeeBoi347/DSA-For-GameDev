using UnityEngine;

public class RandomTest : MonoBehaviour, IRandomTest
{
    public static RandomTest instance;
    #region References
    public void ITestingFunction() => TestingFunction();
    #endregion

    private void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void TestingFunction()
    {
        Debug.Log("Random");
    }
}