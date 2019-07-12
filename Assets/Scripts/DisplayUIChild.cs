using UnityEngine;
using UnityEngine.UI;

public class DisplayUIChild : MonoBehaviour
{
    //Começa com todos os filhos que tiverem componentes de texto, desativados
    void Start()
    {
        this.GetComponentInChildren<Text>().enabled = false;
    }

    //Função criada para habilitar o componente "texto" no momento que o jogador passar o mouse por cima do colisor do objeto e não habilitar caso estiver pausado (função própria do Unity)
    void OnMouseOver() 
    {
        GetComponentInChildren<Text>().enabled = true;
        
        if(ManagerTime.GameIsPaused == true)
        {
            GetComponentInChildren<Text>().enabled = false;
        }
    }

    //Função criada para desabilitar o componente "texto" no momento que o jogador retira o mouse de cima do colisor do objeto (função própria do Unity)
    void OnMouseExit() 
    {
        GetComponentInChildren<Text>().enabled = false;
    }
}