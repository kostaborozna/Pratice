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

    void Start()
    {
        turretToBuild = standartTurrentPrefab;
    }

    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
