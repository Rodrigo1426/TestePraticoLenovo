using UnityEngine;

public class teste : MonoBehaviour
{
    /*private GameObject activateCamera;
    public void disableCamera(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (tag);
        foreach (GameObject target in gameObjects)
        {
            gameObject.
        }
    }

    public void turnON()
    {
        activateCamera.SetActive (true);
    }*/

    public string tagName;
    private GameObject[] A;
    public void desabilitar (string tag){
        if (gameObject.tag == "MainCamera") 
        {
                A = GameObject.FindGameObjectsWithTag (tagName);
            foreach (GameObject B in A) 
            {
                gameObject.SetActive (true);
            }
            }
        }
}
