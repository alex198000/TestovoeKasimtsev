using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class ButtonsESCScript : MonoBehaviour
    {
        [SerializeField] private MenuScript _menuScript;
        [SerializeField] private GameObject _exitMenu;
        [SerializeField] private GameObject _setMenu;

        void Update()
        {
            ESCbutton();
        }
        void ESCbutton()                             // кнопка esc или  шаг назад на телефоне
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _setMenu.transform.position.y < 0)
            {
                _menuScript.ExitGamePanel();
            }
            
            if (Input.GetKeyDown(KeyCode.Escape) && _exitMenu.transform.position.y < 0)
            {
                _menuScript.SettingsPanel();
            }
        }
    }
}