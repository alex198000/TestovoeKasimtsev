using UnityEngine;

namespace Game
{
    public class ButtonsControl : MonoBehaviour
    {
        [SerializeField] private HippoMoove _hippoMoove;
        [SerializeField] private PersonsAttack _gippoAttack;
        [SerializeField] private UIButtons _uiButtons;
        [SerializeField] private float _gravSnowBall = 0.5f;

        void Update()
        {
            MooveBut();
            ESCbutton();
        }
        public void MooveBut()                        // управление с клавиатуры
        {
            if (Input.GetKeyDown(KeyCode.Q)) 
            {                
                _gippoAttack.Fire(false, _gravSnowBall);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _hippoMoove.LeftMove();
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _hippoMoove.StopMove();
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _hippoMoove.RightMove();
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                _hippoMoove.StopMove();
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _hippoMoove.UpMove();
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                _hippoMoove.StopMove();
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                _hippoMoove.DownMove();
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                _hippoMoove.StopMove();
            }
        }
        void ESCbutton()                             // кнопка esc или  шаг назад на телефоне
        {
            if(Input.GetKeyDown(KeyCode.Escape))   
                _uiButtons.PauseButton();           
        }
    }
}