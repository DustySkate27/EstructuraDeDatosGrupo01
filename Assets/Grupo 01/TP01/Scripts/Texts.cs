using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Grupo_01.TP01.Scripts
{
    public class Texts : MonoBehaviour
    {
        private TextMeshProUGUI resultText;


        private void Start()
        {
            resultText = GetComponent<TextMeshProUGUI>();
        }



    }
}
