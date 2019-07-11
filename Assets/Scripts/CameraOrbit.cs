using UnityEngine;
using System.Collections;
 
public class CameraOrbit : MonoBehaviour
{
    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;
 
    protected Vector3 _LocalRotation;

    private GameObject[] cameraList;

    protected float _CameraDistance = 5f;
 
    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;

    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public float distMin;
    public float distMax;
 
    public bool CameraDisabled = false;

    //Executa antes do void Start para garantir que todos os componentes "Camera" serão desativados
    private void Awake()
    {
        StartCoroutine(LateStart());  
    }

    //Desabilita os componentes "Camera" de cada objeto e habilita somente o componente "Camera" do objeto "MainCamera1"
    IEnumerator LateStart()
     {
        yield return new WaitForSeconds(0.1f);

        var camComp = GetComponents<Camera>();
        foreach(var compCam in camComp)
        {
            compCam.enabled = false;
        }

        GameObject.Find("MainCamera1").GetComponent<Camera>().enabled = true;
    }

    void Start() 
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }
 
    void LateUpdate() 
    {
        //Habilita a variável CameraDisable parando a câmera
        if (Input.GetKeyDown(KeyCode.LeftShift))
            CameraDisabled = !CameraDisabled;
 
        if (!CameraDisabled)
        {
            //Rotação da câmera baseada nas coordenadas do mouse
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;
 
                //Prende a rotação do eixo Y no horizonte e não vira no topo
                if (_LocalRotation.y < 0f)
                    _LocalRotation.y = 0f;
                else if (_LocalRotation.y > 90f)
                    _LocalRotation.y = 90f;
            }
            //Zoom pelo scroll do mouse
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;
 
                ScrollAmount *= (this._CameraDistance * 0.3f);
 
                this._CameraDistance += ScrollAmount * -1f;
 
                this._CameraDistance = Mathf.Clamp(this._CameraDistance, distMin, distMax);
            }
        }
 
        //Posições em tempo real do transform da câmera
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);
 
        if ( this._XForm_Camera.localPosition.z != this._CameraDistance * -1f )
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
        }
    }
}