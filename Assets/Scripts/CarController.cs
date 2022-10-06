using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float carSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float Traction;
    [SerializeField] float stearAngle;
    public Transform lw, rw;
    private Vector3 rotVec;
    private float dragAmount=0.99f;
    private Vector3 _moveVec;
    void Start()
    {
        
    }

    void Update()
    {
        _moveVec += transform.forward * carSpeed * Time.deltaTime;
        transform.position += _moveVec * Time.deltaTime;
        transform.Rotate(Vector3.up*Input.GetAxis("Horizontal")*stearAngle*Time.deltaTime*_moveVec.magnitude);
        rotVec += new Vector3(0, Input.GetAxis("Horizontal"), 0);
        rotVec = Vector3.ClampMagnitude(rotVec, stearAngle);
        lw.localRotation = Quaternion.Euler(rotVec);
        rw.localRotation = Quaternion.Euler(rotVec);
        _moveVec *= dragAmount;
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed);
        _moveVec = Vector3.Lerp(_moveVec.normalized, transform.forward, Traction * Time.deltaTime) * _moveVec.magnitude;
    }
}
