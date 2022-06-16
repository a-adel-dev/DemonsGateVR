using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DaemonsGate.UI
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] Image foregroundImage;
        [SerializeField] Image backgroundImage;
        void LateUpdate()
        {

        }

        public void SetHealthBarPercentage(float percentage)
        {
            float parentWidth = GetComponent<RectTransform>().rect.width;
            float width = parentWidth * percentage;
            foregroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }
    }

}