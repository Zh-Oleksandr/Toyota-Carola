using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoCannonScript : MonoBehaviour
{
    public int size = 2;

    public float firerate = 10;

    [SerializeField] private float firecountdown;
    [SerializeField] private bool cooldowncheck = false;

    public GameObject bullet;

    public void Fire()
    {
        if (cooldowncheck == false)
        {


            Instantiate(bullet, transform.position, transform.rotation);

            Cooldown();
        }
        else return;
    }

    public void Cooldown()
    {
        firecountdown = 1 / firerate;
        cooldowncheck = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        firecountdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldowncheck == true && firecountdown > 0)
        {
            firecountdown -= Time.deltaTime;
        }
        else
        {
            cooldowncheck = false;
        }
        if (this.GetComponentInParent<UniversalMovement>().notai == true)
        {
                if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
                {
                    Fire();
                }
        }
    }
}
