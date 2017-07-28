﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;
using UnityEngine.UI;

namespace InscriptionSystem.UI {
    /// <summary>
    /// 当个符文属性显示面板
    /// </summary>
    public class InscriptionAttributePanel : MonoBehaviour {

        /// <summary>
        /// 符文显示图标设置
        /// </summary>
        public Image inscriptionsprite;

        /// <summary>
        /// 符文属性显示设置
        /// </summary>
        public Text attributeText;

        /// <summary>
        /// SendMessage接受体：接受来自InscriptionAttribueUIController类发来的信息
        /// </summary>
        /// <param name="insc"></param>
        public void OnReceiveMessage(Inscription insc) {
            inscriptionsprite.sprite = insc._inscriptionIcon;
            foreach (InscriptionAttribute a in insc._inscriptionAttribute) {
                string text = a.attributeName;
                if (a.valueType == AttributeValue.NUMBER)
                {
                    text += a._attributeValue.ToString();
                }
                else {
                    text += ((a._attributeValue * 100).ToString() + "%");
                }
                attributeText.text += text;
                attributeText.text += "\n";
            }
        }

        /// <summary>
        /// 按钮响应事件：移除卡槽中的符文
        /// </summary>
        public void OnRemoveInscripteFromSlot() {
            InscriptionSlotButton.currentButton.GetComponent<InscriptionSlotButton>().inscriptionId = 0;
            InscriptionSlotButton.currentButton.GetComponent<Image>().enabled = false;
            InscriptionSlotButton.currentButton.GetComponent<InscriptionSlotButton>().isInscription = false;
        }

        /// <summary>
        /// 按钮响应事件：替换卡槽中的符文
        /// </summary>
        public void OnReplaceInscription() {
            this.gameObject.SetActive(false);
            InscriptionAttribueUIController.Instance.inscriptionSettingPanel.SetActive(true);
            ///SendMessage接受体：发送给InscriptionSettingPanel
            InscriptionAttribueUIController.Instance.inscriptionSettingPanel.SendMessage("OnReceiveMessage");
        }
    }
}