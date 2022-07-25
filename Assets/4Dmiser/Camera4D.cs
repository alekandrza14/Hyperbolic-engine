using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera4D : MonoBehaviour
{
    public float pos4;
    public Vector3 pos3;
    public GameObject telo;
    public Rigidbody rb;

    public float radiuscolider;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        tringle4D.isEditor = false;
    }
    public static Camera4D Main()
    {
        return FindObjectOfType<Camera4D>();
    }

    private void LateUpdate()
    {
        
        
            Ray r = new Ray(telo.transform.position, new Vector3(0, 0, 1));

            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.distance <= radiuscolider)
                {
                    pos3.z += (Time.deltaTime);
                }
            }
        

            Ray r2 = new Ray(telo.transform.position, new Vector3(0, 0, -1));

            RaycastHit hit2;
            if (Physics.Raycast(r2, out hit2))
            {
                if (hit2.distance <= radiuscolider)
                {
                    pos3.z += (-Time.deltaTime);
                }
            }
        



        Ray r3 = new Ray(telo.transform.position, new Vector3(1, 0, 0));


        RaycastHit hit3;
        if (Physics.Raycast(r3, out hit3))
        {
            if (hit3.distance <= radiuscolider)
            {
                pos3.x += (Time.deltaTime);
            }
        }

        Ray r4 = new Ray(telo.transform.position, new Vector3(-1, 0, 0));

        RaycastHit hit4;
        if (Physics.Raycast(r4, out hit4))
        {
            if (hit4.distance <= radiuscolider)
            {
                pos3.x += (-Time.deltaTime);
            }
        }
        Ray r5 = new Ray(telo.transform.position, new Vector3(0, -1, 0));


        RaycastHit hit5;
        if (Physics.Raycast(r5, out hit5))
        {
            if (hit5.distance <= radiuscolider)
            {
                pos3.y += (-Time.deltaTime);
            }
            if (hit5.distance > radiuscolider)
            {
                pos3.y += (Time.deltaTime);
            }
        }
        Debug.DrawRay(telo.transform.position, new Vector3(0, -1, 0));
        

       


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        for (int i = 0; i < FindObjectsOfType<target4D>().Length; i++)
        {
            FindObjectsOfType<target4D>()[i].targetUpdate(pos4, pos3);
        }
        for (int i = 0; i < FindObjectsOfType<tringle4D>().Length; i++)
        {
            FindObjectsOfType<tringle4D>()[i].targetUpdate(pos4, pos3);
        }

        
        //Vertical
        pos3 -= telo.transform.right * Input.GetAxis("Horizontal") * Time.deltaTime+telo.transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            
            pos4 -= Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            
            pos4 += Time.deltaTime;




        }
        targetUpdate(pos4);

        float r1 = Input.GetAxis("Mouse X");
        telo.transform.Rotate(0,r1,0);
        transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);

    }
    public void targetUpdate(float pos42)
    {
        telo.transform.position = pos3 * (pos4);
        telo.transform.position -= pos3;


    }
}
