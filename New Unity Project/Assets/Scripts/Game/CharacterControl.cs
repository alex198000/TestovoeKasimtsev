using UnityEngine;

namespace Game
{
    public class CharacterControl : SpinePersons
    {
        [SerializeField] private SettingsControl _settingsControl;
        [SerializeField] private float _speedPlayer;
              
        private Vector3 _position;

        private void OnEnable()
        {
            Timer.OnEndGame += HippoDeactiv;
            LevelManager.OnWinGame += HippoDeactiv;
        }

        private void OnDisable()
        {
            Timer.OnEndGame -= HippoDeactiv;
            LevelManager.OnWinGame -= HippoDeactiv;
        }

        private void Start()
        {
            
            _speedPlayer = _settingsControl.GippoSpeed;
        }
        void Update()
        {
            
            _position = new Vector3(0f, SimpleInput.GetAxis("Vertical"), 0f);          // SimpleInput.GetAxis("Horizontal"),     //если нужно будет двигаться по х
           
            if (SimpleInput.GetAxis("Vertical") == 0)
            {
                UpMove();
                //Walk();
            }
            if (SimpleInput.GetAxis("Vertical") != 0)
            {
                //Idle();
                _animPerson.AnimationName = "idle";
            }
            transform.position += _position * Time.deltaTime * _speedPlayer;          
        }

        protected override void Idle()
        {
            float timeAnime = _animPerson.skeleton.Data.FindAnimation("Idle").Duration;
            _animPerson.state.SetAnimation(0, "Idle", true);
            _animPerson.state.AddAnimation(0, "Applause", true, timeAnime); 
        }
        protected override void Walk()
        {
            base.Walk();
        }
        void HippoDeactiv()
        {
            gameObject.SetActive(false);
        }
    }
}