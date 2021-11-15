using UnityEngine;

namespace Game
{
    public class ButtonsControl : MonoBehaviour
    {
        [SerializeField] private SpinePersons _spineGippo;
        [SerializeField] private PersonsAttack _gippoAttack;
        [SerializeField] private UIButtons _uiButtons;

        void Update()
        {
            MooveBut();
            ESCbutton();
        }
        public void MooveBut()                        // управление с клавиатуры
        {
            if (Input.GetKeyDown(KeyCode.Q)) 
            {                
                _gippoAttack.Fire(false, 0.02f);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _spineGippo.LeftMove();
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _spineGippo.StopMove();
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _spineGippo.RightMove();
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                _spineGippo.StopMove();
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _spineGippo.UpMove();
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                _spineGippo.StopMove();
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                _spineGippo.DownMove();
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                _spineGippo.StopMove();
            }
        }
        void ESCbutton()                             // кнопка esc или  шаг назад на телефоне
        {
            if(Input.GetKeyDown(KeyCode.Escape))   
                _uiButtons.PauseButton();           
        }
    }
}