using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    public PolarTransform p2 = new PolarTransform();
    public Vector3 ls;
    public float v1 = 0;
    public bool px; public bool py; public bool mx; public bool my;

    public void move()
    {
        if (px)
        {
            p2.preApplyTranslationY(-1);
            px = !px;
        }
        if (mx)
        {
            p2.preApplyTranslationY(1);
            mx = !mx;
        }
        if (py)
        {
            p2.preApplyTranslationZ(-1);
            py = !py;
        }
        if (my)
        {
            p2.preApplyTranslationZ(1);
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


            

            prevPoint = nextPoint;


        }
        
        transform.localScale = ls * MathHyper.Facteur2(gameObject, transform.position);
    }
}
