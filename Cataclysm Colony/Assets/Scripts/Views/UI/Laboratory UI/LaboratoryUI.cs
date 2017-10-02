using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryUI : MonoBehaviour {

    public LaboratoryController laboratoryController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    void OnEnable()
    {

        if (laboratoryController == null)
            laboratoryController = GameController.Instance.baseController.laboratoryController;

        UIController.Instance.lockOtherInput = true;

    }
    void OnDisable()
    {
        UIController.Instance.lockOtherInput = false;
    }

}
