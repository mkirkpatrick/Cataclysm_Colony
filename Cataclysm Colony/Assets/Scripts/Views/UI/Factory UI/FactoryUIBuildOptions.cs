using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUIBuildOptions : MonoBehaviour {

    public Button itemIncreaseButton;
    public Button itemDecreaseButton;
    public InputField itemCount;

    public Button colonistIncreaseButton;
    public Button colonistDecreaseButton;
    public InputField colonistCount;

    public Transform upgradesContainer;

    private FactoryUI factoryUI;

    void Start() {
        factoryUI = UIController.Instance.factoryUI;
    }

    void Update() {
            itemCount.text = factoryUI.factoryUIData.buildCount.ToString();
            colonistCount.text = factoryUI.factoryUIData.colonistAssignedCount.ToString();
    }
}
