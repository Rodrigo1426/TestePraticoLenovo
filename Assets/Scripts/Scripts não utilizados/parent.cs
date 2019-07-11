using UnityEngine;

public class parent : MonoBehaviour
{
    public GameObject MainCamera;
    Vector3 originalPos;

    void Start()
    {
        originalPos = gameObject.transform.position;
    }
    public void changeCam()
    {
        gameObject.transform.parent = MainCamera.transform;
        gameObject.transform.position = originalPos;
    }

    void Update() 
    {
        changeCam();
    }
}