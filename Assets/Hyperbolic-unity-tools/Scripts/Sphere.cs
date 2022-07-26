using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    public PolarTransform p2 = new PolarTransform();
    public PolarTransform p3 = new PolarTransform();
    public Vector3 ls;
    public float v1 = 0;
    public float x;
    public bool px; public bool py; public bool mx; public bool my;

    public void move()
    {
        if (px)
        {
            p2.preApplyTranslationY(-1*x * 0.02f);
            px = !px;
        }
        if (mx)
        {
            p2.preApplyTranslationY(1 * x * 0.02f);
            mx = !mx;
        }
        if (py)
        {
            p2.preApplyTranslationZ(-1 * x * 0.02f);
            py = !py;
        }
        if (my)
        {
            p2.preApplyTranslationZ(1 * x*0.02f);
            my = !my;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    static public void ALLSpheresRot(float r)
    {
        for (int i = 0; i < ALLSpheres().Length;i++)
        {
            float ds = MathHyper.Facteur2(ALLSpheres()[i].gameObject, ALLSpheres()[i].transform.position);
            ALLSpheres()[i].transform.rotation = Quaternion.Euler(ALLSpheres()[i].transform.rotation.eulerAngles.x, ALLSpheres()[i].transform.rotation.eulerAngles.y - r / Time.deltaTime *3.14f * ds, ALLSpheres()[i].transform.rotation.eulerAngles.z);

        }
    }
    static public Sphere[] ALLSpheres()
    {
        return GameObject.FindObjectsOfType<Sphere>();
    }
    public Vector3 newrot()
    {
        Vector3 v6 = new Vector3();
        
        PMatrix3D copytr = new PMatrix3D();
        copytr.set(p3.getMatrix());

        PVector prevPoint = new PVector();
        float ds = MathHyper.Facteur2(gameObject, transform.position);
        float inc = 0.1f;
        for (float i = 0; i < inc * 2; i += inc)
        {
            PVector nextPoint = MathHyper.polarVector(i, 1.255f);



            copytr.mult(nextPoint, nextPoint);
            Camd.Main().polarTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);

            if (i >= inc)
            {
               v6 = new Vector3(prevPoint.x, v1 * ds, prevPoint.y);

            }




            prevPoint = nextPoint;


        }
        return v6;
    }

    // Update is called once per frame
    public void Update()
    {
        PMatrix3D copytr = new PMatrix3D();
        copytr.set(p2.getMatrix());

        PVector prevPoint = new PVector();
        //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")
        float ds = MathHyper.Facteur2(gameObject, transform.position);
        float inc = 0.1f;
        for (float i = 0; i < inc * 2; i += inc)
        {
            PVector nextPoint = MathHyper.polarVector(i, 1.255f);
            //Apply currentTransform on nextPoint and save the result in nextPoint 



            copytr.mult(nextPoint, nextPoint);
            Camd.Main().polarTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);
            
                if (i >= inc)
                {
                    transform.position = new Vector3(prevPoint.x, v1 * ds, prevPoint.y);
                
            }

            var look_dir = newrot() - transform.position;
            look_dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), 1000 * Time.deltaTime);


            prevPoint = nextPoint;


        }
        
        transform.localScale = ls * MathHyper.Facteur2(gameObject, transform.position);
    }
}
