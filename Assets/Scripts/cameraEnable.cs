using UnityEngine;

public class cameraEnable : MonoBehaviour
{
    private GameObject[] cameraList;

    void Start()
    {
        //Atribuindo um valor a variável dizendo que faz parte dela objetos que contem a Tag MainCamera
        cameraList = GameObject.FindGameObjectsWithTag("MainCamera");
    }

    //Função que desabilita o objeto que tem como Tag "MainCamera"
    public void Disable()
    {
        //Faz uma varredura de todos Objetos que possuem como Tag "MainCamera" e os desabilita
        foreach(GameObject obj in cameraList)
        {
            obj.SetActive(false);
        }

        //Faz uma varredura de todos Objetos que possuem como coliso "BoxCollider" e os desabilita
        var colisor = GetComponentsInChildren<BoxCollider>();
        foreach(var childCollider in colisor)
        {
            childCollider.enabled = false;
        }
    }
}