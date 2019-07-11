using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range (0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = false;

    public float RotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer) transform.LookAt(PlayerTransform);*/

        if (PlayerTransform)
        {
            if (Input.touchCount == 1)
            {
                RotationSpeed = RotationSpeed * Input.touches[0].deltaPosition.x;
                Quaternion camTurnAngle = Quaternion.AngleAxis(RotationSpeed, Vector3.up);
                _cameraOffset = camTurnAngle * _cameraOffset;
            }
            Vector3 newPos = PlayerTransform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position,newPos, Time.deltaTime * SmoothFactor);
            transform.LookAt(PlayerTransform);
        }
    }
}
