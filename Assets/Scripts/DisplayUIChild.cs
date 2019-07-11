using UnityEngine;
using UnityEngine.UI;

public class DisplayUIChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<Text>().enabled = false;
    }

    //função criada para habilitar o componente "texto" no momento que o jogador passar o mouse por cima do colisor do objeto e não habilitarcaso estiver pausado (função própria do Unity)
    void OnMouseOver() 
    {
        GetComponentInChildren<Text>().enabled = true;
        
        if(ManagerTime.GameIsPaused == true)
        {
            GetComponentInChildren<Text>().enabled = false;
        }
    }

    //função criada para desabilitar o componente "texto" no momento que o jogador retira o mouse de cima do colisor do objeto (função própria do Unity)
    void OnMouseExit() 
    {
        GetComponentInChildren<Text>().enabled = false;
    }
}