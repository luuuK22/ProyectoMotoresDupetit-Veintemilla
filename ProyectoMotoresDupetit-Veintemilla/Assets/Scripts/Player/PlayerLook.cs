using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TP FINAL - MATEO DUPETIT
public class PlayerLook : MonoBehaviour
{

    [SerializeField] private Camera playerCamera;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private float lookXLimit = 45f;

    private float rotationX;
    private bool canLook = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Awake()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;


        rotationX = playerCamera.transform.localEulerAngles.x;
        if (rotationX > 180f) rotationX -= 360f;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
        if (!canLook) return;

        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX += -mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.rotation *= Quaternion.Euler(0f, mouseX, 0f);
    }

    public void SetCanLook(bool value) => canLook = value;

    public void SyncFromCamera()
    {
        rotationX = playerCamera.transform.localEulerAngles.x;
        if (rotationX > 180f) rotationX -= 360f;
    }
}


