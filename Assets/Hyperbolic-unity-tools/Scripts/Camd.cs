using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camd : MonoBehaviour
{
    public PolarTransform polarTransform = new PolarTransform(0, 0.01f, 0f);
    public bool px; public bool py; public bool mx; public bool my;
    public BoxCollider c;
    public float startscale;
    public Rigidbody rb;
    public Light light1;
    public float radiuscolider;
    public float x;
    public void move()
    {
        if (px)
        {
            polarTransform.preApplyTranslationY(-1 * x * 0.02f);
            px = !px;
        }
        if (mx)
        {
            polarTransform.preApplyTranslationY(1 * x * 0.02f);
            mx = !mx;
        }
        if (py)
        {
            polarTransform.preApplyTranslationZ(-1 * x * 0.02f);
            py = !py;
        }
        if (my)
        {
            polarTransform.preApplyTranslationZ(1 * x * 0.02f);
            my = !my;
        }
    }
    void OnCollisionEnter(Collision c)
    {
        


            
    }

        // Start is called before the first frame update
        void Start()
    {
        
        tringle.iseditor = false;
    }
    public static Camd Main()
    {
        return FindObjectsOfType<Camd>()[0];
    }
    private void LateUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            Ray r = new Ray(transform.position, new Vector3(0, 0.5f, 1) + transform.position);

            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.distance <= radiuscolider)
                {
                    polarTransform.preApplyTranslationZ(Time.deltaTime);
                }
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {


            Ray r2 = new Ray(transform.position, new Vector3(0, 0.5f, -1) + transform.position);

            RaycastHit hit2;
            if (Physics.Raycast(r2, out hit2))
            {
                if (hit2.distance <= radiuscolider)
                {
                    polarTransform.preApplyTranslationZ(-Time.deltaTime);
                }
            }
        }



        Ray r3 = new Ray(transform.position, new Vector3(1, 0.5f, 0) + transform.position);


        RaycastHit hit3;
        if (Physics.Raycast(r3, out hit3))
        {
            if (hit3.distance <= radiuscolider)
            {
                polarTransform.preApplyTranslationY(Time.deltaTime);
            }
        }

        Ray r4 = new Ray(transform.position, new Vector3(-1, 0.5f, 0) + transform.position);

        RaycastHit hit4;
        if (Physics.Raycast(r4, out hit4))
        {
            if (hit4.distance <= radiuscolider)
            {
                polarTransform.preApplyTranslationY(-Time.deltaTime);
            }
        }


    }

        // Update is called once per frame
        void Update()
    {

        for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
        {
            GameObject.FindObjectsOfType<tringle>()[i].up2(polarTransform);

        }
        for (int i = 0; i < GameObject.FindObjectsOfType<Sphere>().Length; i++)
        {
            GameObject.FindObjectsOfType<Sphere>()[i].Update();
        }
        transform.position = new Vector3(0, transform.position.y, 0);
        //Vertical

      Vector3 v =  Vector3.MoveTowards(Vector3.zero,new Vector3(-Input.GetAxis("Vertical") * Time.deltaTime, -Input.GetAxis("Horizontal") * Time.deltaTime),2);
        
        polarTransform.preApplyTranslationZ(v.x);
        polarTransform.preApplyTranslationY(v.y);
       



        float r1 = Input.GetAxis("Mouse X") * Time.deltaTime;
        polarTransform.preApplyRotation(r1);

        light1.transform.rotation = Quaternion.Euler(light1.transform.rotation.eulerAngles.x, light1.transform.rotation.eulerAngles.y - r1 / Time.deltaTime, light1.transform.rotation.eulerAngles.z);
        Sphere.ALLSpheresRot(r1);
        transform.Rotate(-Input.GetAxis("Mouse Y")+ Random.Range(-0.01f, 0.01f), 0, Random.Range(-0.01f, 0.01f));

    }
}
