using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
public class TestUnitTesting
{
    private PlayerMovement playerMovement;
    private GameObject playerObj;

    [SetUp]
    public void Setup()
    {
        playerObj = new GameObject();
        playerMovement = playerObj.AddComponent<PlayerMovement>();
    }

    [TearDown] // <summary> : Called after all tests are done
    public void TearDown()
    {
        Object.DestroyImmediate(playerObj);
    }

    [Test] 
    public void PlayerStartsAtZero()
    {
        Assert.AreEqual(playerObj.transform.position.x, 0);
    }

    [UnityTest]
    public IEnumerator PlayerMoveTowardsLeft()
    {
        Vector3 startPos = playerObj.transform.position;
        playerMovement.MoveDirection(Vector3.left);
        yield return null;
        Assert.Less(playerMovement.transform.position.x, startPos.x);
    }

    [UnityTest]

    public IEnumerator PlayerMoveTowardsRight()
    {
        Vector3 startPos = playerObj.transform.position;
        playerMovement.MoveDirection(Vector3.right);
        yield return null;
        Assert.Greater(playerMovement.transform.position.x, startPos.x);
    }

    [UnityTest]
    public IEnumerator PlayerJump()
    {
        float yPos = playerObj.transform.position.y;
        playerMovement.JumpPlayer();
        yield return null;
        Assert.Greater(playerMovement.transform.position.y, yPos);
    }
}
