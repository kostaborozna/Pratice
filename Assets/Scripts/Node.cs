using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;

    public Color notEnoughMoneyColor;
    public Vector3 positonOffset;

    [HideInInspector]
    public GameObject turrent;
    [HideInInspector]
    public TurrentBluePrint turrentBluePrint;
    [HideInInspector]
    public bool isUpraded = false;

    private Renderer rend;

    BuildManager buildManager;

    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;

    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positonOffset;
    }


   

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

       

        if (turrent != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;
        //Build a turret

        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void BuildTurret(TurrentBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.cost)
        {
            Debug.Log("Нету мани");
            return;
        }

        PlayerStats.Money -= bluePrint.cost;
        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turrent = _turret;
        turrentBluePrint = bluePrint;

        Debug.Log("Успех турелька есть я ебать прогграимст" + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turrentBluePrint.upgradeCost)
        {
            Debug.Log("Нету мани на апгрейд");
            return;
        }
        // Старую нахуй
        Destroy(turrent);
        // Новую на место
        PlayerStats.Money -= turrentBluePrint.upgradeCost;
        GameObject _turret = (GameObject)Instantiate(turrentBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turrent = _turret;

        isUpraded = true;

        Debug.Log("Апгрейд" + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turrentBluePrint.GetSellAmount();
        Destroy(turrent);
        turrentBluePrint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }


    }

    void OnMouseExit()
    {
        rend.material.color = startColor;

    }
}
