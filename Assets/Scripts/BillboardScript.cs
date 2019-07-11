using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public Camera my_camera;

    //método que ocorre a cada frame fazendo com que o objeto na qual ele foi atrelado, fique sempre olhando para o jogador
    void Update()
    {
        transform.LookAt (transform.position + my_camera.transform.rotation * Vector3.forward, my_camera.transform.rotation * Vector3.up);
    }
}
