using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camd : MonoBehaviour
{
    public PolarTransform polarTransform = new PolarTransform(0, 0.01f, 0f);
    public bool px; public bool py; public bool mx; public bool my;
    public Light light1;
    public void move()
    {
        if (px)
        {
            polarTransform.preApplyTranslationY(-1);
            px = !px;
        }
        if (mx)
        {
            polarTransform.preApplyTranslationY(1);
            mx = !mx;
        }
        if (py)
        {
            polarTransform.preApplyTranslationZ(-1);
            py = !py;
        }
        if (my)
        {
            polarTransform.preApplyTranslationZ(1);
            my = !my;
        }
    }
        
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static Camd Main()
    {
        return FindObjectsOfType<Camd>()[0];
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

        //Vertical
        polarTransform.preApplyTranslationZ(-Input.GetAxis("Vertical") * Time.deltaTime);
        polarTransform.preApplyTranslationY(-Input.GetAxis("Horizontal") * Time.deltaTime);
        float r = Input.GetAxis("Mouse X") * Time.deltaTime;
        polarTransform.preApplyRotation(r);
        light1.transform.rotation = Quaternion.Euler(light1.transform.rotation.eulerAngles.x, light1.transform.rotation.eulerAngles.y - r / Time.deltaTime, light1.transform.rotation.eulerAngles.z);
        transform.Rotate(-Input.GetAxis("Mouse Y"),0,0);

    }
}
