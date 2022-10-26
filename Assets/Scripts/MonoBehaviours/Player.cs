using Cinemachine.Utility;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("Refs")]
    public Camera Camera;
    public ParticleSystem ShootFX;
    public Transform Muzzle;

    [Header("Settings")]
    public LayerMask GroundLayerMask;
    public float MoveSpeed = 5f;

    public bool Shoot;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _camera = Camera;
    }

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(_mousePos);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, GroundLayerMask, QueryTriggerInteraction.Ignore))
        {
            Vector3 hitPoint = hitInfo.point;
            hitPoint.y = transform.position.y;
            transform.LookAt(hitPoint, Vector3.up);
        }

        Vector3 moveVector = _camera.transform.localRotation * _inputVector;
        moveVector = moveVector.ProjectOntoPlane(Vector3.up);
        transform.position += moveVector * Time.deltaTime * MoveSpeed;
    }

    void OnMove(InputValue value)
    {
        _inputVector = value.Get<Vector2>();
    }

    void OnShoot(InputValue value)
    {
        if (ShootFX)
            ShootFX.Play();

        Shoot = true;
    }

    void OnMousePos(InputValue value)
    {
        _mousePos = value.Get<Vector2>();
    }

    Camera _camera;
    Vector2 _mousePos;
    Vector2 _inputVector;
}
