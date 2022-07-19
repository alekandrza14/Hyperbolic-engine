using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camd : MonoBehaviour
{
    public PolarTransform polarTransform = new PolarTransform(0,0.01f,0f);
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
        polarTransform.preApplyRotation(Input.GetAxis("Mouse X") * Time.deltaTime);
        transform.Rotate(-Input.GetAxis("Mouse Y"),0,0);

    }
}
