using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform marker;
    Vector3 nullPosition;
    [SerializeField] Transform armPivot;
    Transform lookPivot;
    Camera cam;
    [SerializeField] float distance = 300;
    public GameObject particle;
    public ParticleSystem _part;
    public Text count;
    private int _countEnemies = 0;
    public Text win;
    public GameObject crosshair;
    public AudioSource deagle;
    public AudioSource omg;

    private void Awake()
    {
        _part.Stop();
        crosshair.transform.localScale = new Vector3(1f, 1f, 1f);
        deagle.Stop();
        omg.Stop();
    }
    void aiming()
    {
        Ray ray;
        RaycastHit hit;
        bool isAiming;
        ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        isAiming = false;
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.transform.tag == "Target")
            {
                marker.position = hit.point;
                isAiming = true;
            }
        }
        if (!isAiming && marker.transform.position != nullPosition)
            marker.transform.position = nullPosition;
    }

    

    void shooting()
    {
        Ray ray;
        RaycastHit hit;
        

        if (Input.GetMouseButtonUp(0))
            _part.Stop();
            crosshair.transform.localScale = new Vector3(1f, 1f, 1f);

        if (Input.GetMouseButtonDown(0))
        {
            deagle.Play();
            crosshair.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            _part.Play();
            ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.tag == "Target")
                {
                    Destroy(hit.transform.gameObject);
                    omg.Play();
                    _countEnemies++;
                    count.text = "Убил врагов: " + _countEnemies;
                    if (_countEnemies == 30)
                    {
                        win.text = "Поздравляю, ты спасся от инопланетян!";
                    }
                }
            }
        }
    }

    void rotateArm()
    {
        Vector3 euler;
        euler = armPivot.eulerAngles;
        euler.x = lookPivot.eulerAngles.x;
        armPivot.eulerAngles = euler;
    }
    private void Start()
    {
        nullPosition = marker.position;
        cam = Camera.main;
        lookPivot = cam.transform;
    }
    private void Update()
    {
        rotateArm();
        aiming();
        shooting();
    }
}
