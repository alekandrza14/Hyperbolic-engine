using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class editorsave
{
    public PolarTransform pos;

}
[ExecuteAlways]
public class load : MonoBehaviour
{

}
[ExecuteAlways]
[AddComponentMenu("Hyperbolic space/Hyperbolic Player Controler")]
public class Camd : MonoBehaviour
{
    Vector4 oldposition;
    
    [HideInInspector] public Vector4 position;


    [HideInInspector] public PolarTransform polarTransform = new PolarTransform(0, 0.01f, 0f);
    [HideInInspector] public bool px;[HideInInspector] public bool py;[HideInInspector] public bool mx;[HideInInspector] public bool my;
    [HideInInspector] public BoxCollider c;
    [HideInInspector] public float startscale;
    [HideInInspector] public Quaternion rotation;
    [Header("=============")]
    [Header("Physics")]
    public Rigidbody rb;
    public float radiuscolider;
    [Header("=============")]
    [Header("Lighting")]
    public Light light1;

    [HideInInspector] public float x;
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
    private void Start()
    {
        tringle.iseditor = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionEnter(Collision c)
    {

        if (c.collider.tag == "deadpol")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

            
    }

        // Start is called before the first frame update
    
    public static Camd Main()
    {
        return FindObjectsOfType<Camd>()[0];
    }
    private void LateUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            Ray r = new Ray(transform.position, new Vector3(0, 0.5f, 1));

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


            Ray r2 = new Ray(transform.position, new Vector3(0, 0.5f, -1));

            RaycastHit hit2;
            if (Physics.Raycast(r2, out hit2))
            {
                if (hit2.distance <= radiuscolider)
                {
                    polarTransform.preApplyTranslationZ(-Time.deltaTime);
                }
            }
        }



        Ray r3 = new Ray(transform.position, new Vector3(1, 0.5f, 0));


        RaycastHit hit3;
        if (Physics.Raycast(r3, out hit3))
        {
            if (hit3.distance <= radiuscolider)
            {
                polarTransform.preApplyTranslationY(Time.deltaTime);
            }
        }

        Ray r4 = new Ray(transform.position, new Vector3(-1, 0.5f, 0));

        RaycastHit hit4;
        if (Physics.Raycast(r4, out hit4))
        {
            if (hit4.distance <= radiuscolider)
            {
                polarTransform.preApplyTranslationY(-Time.deltaTime);
            }
        }


    }
    public void edit()
    {
        transform.rotation = rotation;
    }


        // Update is called once per frame
   public void Update()
    {
        if (position != oldposition)
        {


            polarTransform = new PolarTransform(position.x, position.y, position.z);
            transform.position = new Vector3(0,position.w,0);
        }
        position = new Vector4(polarTransform.n, polarTransform.s, polarTransform.m, transform.position.y);
        if (Directory.Exists("Assets") && Input.GetKeyDown(KeyCode.F1))
        {
            editorsave es = new editorsave();
            es.pos = polarTransform;
            File.WriteAllText("Assets/player.json",JsonUtility.ToJson(es));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        for (int i = 0; i < GameObject.FindObjectsOfType<Sphere>().Length; i++)
        {
            GameObject.FindObjectsOfType<Sphere>()[i].Update();
        }
       
        //Vertical

      Vector3 v =  Vector3.MoveTowards(Vector3.zero,new Vector3(-Input.GetAxis("Vertical") * Time.deltaTime, -Input.GetAxis("Horizontal") * Time.deltaTime),2);
        
        polarTransform.preApplyTranslationZ(v.x);
        polarTransform.preApplyTranslationY(v.y);
        
        if (Input.GetKeyDown(KeyCode.F5))
        {
            transform.rotation = rotation;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {



            float r1 = Input.GetAxis("Mouse X") * Time.deltaTime *1.5f;
            polarTransform.preApplyRotation(r1);

            
            
        }
        oldposition = position;
    }
}
