using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager");
            return;
        }
        instance = this;

    }
    public GameObject standartTurrentPrefab;

    public GameObject missileLauncherPrefab;



    private TurrentBluePrint turretToBuild;

    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurrentBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectTurretToBuild(TurrentBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
}
