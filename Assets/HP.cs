using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{

    public Image hp;
    private float fill;
    public Text lose;
    public GameObject canvas;
    public GameObject hand1, hand2, crosshair;
    public Weapon playerWeapon;
    

    void Start()
    {
        fill = 1f;
        playerWeapon.GetComponent<Weapon>().enabled = true;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Target")
        {
            fill -= 0.4f * Time.deltaTime;
            hp.fillAmount = fill;
            if (fill <= 0f)
            {
                lose.text = "ÏÎÒÐÀ×ÅÍÎ";
                canvas.SetActive(false);
                hand1.SetActive(false);
                hand2.SetActive(false);
                crosshair.SetActive(false);
                playerWeapon.GetComponent<Weapon>().enabled = false;
            }
        }
    }
}

