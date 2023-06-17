using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellAmount;
    private Node target;
    public Button upgradeButton;
    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        upgradeCost.text = "$" + target.turrentBluePrint.upgradeCost.ToString();

        if (!target.isUpraded)
        {
            upgradeCost.text = "$" + target.turrentBluePrint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "уюпе";
        }

        sellAmount.text = "$" + target.turrentBluePrint.GetSellAmount().ToString();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();

    }
}
