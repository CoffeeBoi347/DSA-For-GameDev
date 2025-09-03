using UnityEngine;

public class PlayerOperationsLT : MonoBehaviour
{
    [SerializeField] private GameObject _testObj;

    private void Start()
    {
        MovePlayer();
        ScalePlayer();
        RotatePlayer();
        ChangeColor();
        FadePlayer();
    }

    public void MovePlayer()
    {
        LeanTween.move(_testObj, new Vector3(6, 1, 0), 1.5f); // gameObject, Vector3 newPos, float time
    }

    public void ScalePlayer()
    {
        LeanTween.scale(_testObj, new Vector3(5, 5, 5), 1.5f); // gameObject, Vector3 newPos, float time
    }

    public void RotatePlayer()
    {
        LeanTween.rotateZ(_testObj, 180f, 1.5f); // gameObject, float newPos, float time
    }

    public void ChangeColor()
    {
        LeanTween.color(_testObj, Color.red, 1.5f); // gameObject, Vector3 color, float time
    }

    public void FadePlayer()
    {
        LeanTween.alpha(_testObj, 0f, 1.5f); // gameObject, float alpha, float time
    }
}
