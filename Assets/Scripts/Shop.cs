using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurrentBluePrint standartTurent;
    public TurrentBluePrint misssileLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandartTurrent()
    {
        Debug.Log("Standart Turrent Push");
        buildManager.SelectTurretToBuild(standartTurent);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Misele Turrent Push");
        buildManager.SelectTurretToBuild(misssileLauncher);
    }
}
