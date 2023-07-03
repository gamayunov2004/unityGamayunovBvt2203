using MapMagic.Nodes;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed = 400f;
    public float speedRotate = 100f;
    public float jumpForce = 30f;
    private Rigidbody _rb;

    public Transform cameraTransform;
    public Transform handTransform;
    public Transform handTransform2;
    private float rotation;

    public GameObject flash;
    public Image hp;
    private bool isBright = true;

    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Moving();
        Camera();
        Flashing(); 
    }
    
    void Moving()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        
        _rb.velocity = transform.TransformDirection(new Vector3(h, _rb.velocity.y, v));
        
        if (Input.GetKey(KeyCode.Space))
            _rb.AddForce(Vector3.up * jumpForce);
    }

    void Camera()
    {
        float mouseH = Input.GetAxis("Mouse X") * speed * Time.fixedDeltaTime;
        float mouseV = Input.GetAxis("Mouse Y") * -speed * Time.fixedDeltaTime;

        transform.Rotate(0, mouseH, 0);

        rotation += mouseV;
        rotation = Mathf.Clamp(rotation, -89, 89);
        var euler = cameraTransform.transform.localEulerAngles;
        euler.x = rotation;

        cameraTransform.transform.localEulerAngles = euler;
        handTransform.transform.localEulerAngles = euler - new Vector3(90, 0, 0);
        handTransform2.transform.localEulerAngles = euler - new Vector3(90, 0, 0);
    }
    void Flashing()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flash.SetActive(!isBright);
            isBright = !isBright;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "target")
        {
            hp.image.width -= 10;
        }
    }
}
    
