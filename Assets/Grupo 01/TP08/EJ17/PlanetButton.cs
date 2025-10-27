using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class PlanetButton : MonoBehaviour
{
    private Button planetButton;
    private PlanetConfig config;
    [SerializeField] private TP17Executer tpExe;

    // Start is called before the first frame update
    void Start()
    {
        planetButton = GetComponent<Button>();
        config = GetComponent<PlanetConfig>();
        planetButton.onClick.AddListener(() => tpExe.AssignNames(config.PlanetName));
    }

}
