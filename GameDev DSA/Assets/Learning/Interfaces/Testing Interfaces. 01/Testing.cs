using UnityEngine;

public class Testing : MonoBehaviour
{
    private IRandomTest randomTest;

    void Start()
    {
        randomTest = RandomTest.instance;

        randomTest.ITestingFunction();
    }
}