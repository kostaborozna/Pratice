using System.Runtime.CompilerServices;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positonOffset;

    private GameObject turrent;

    private Renderer rend;

   

    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

    }

    void OnMouseDown()
    {
        if(turrent != null)
        {
            Debug.Log("Can't build there - TODO: Display on screen");
        }
        //Build a turret

        GameObject turretToBild = BuildManager.instance.getTurretToBuild();
        turrent = (GameObject)Instantiate(turretToBild, transform.position + positonOffset, transform.rotation);

    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;

    }
}
