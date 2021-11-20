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
           // PersonsAttack.OnHitPersons += Attack;
        }

        private void OnDisable()
        {
            Timer.OnEndGame -= HippoDeactiv;
            LevelManager.OnWinGame -= HippoDeactiv;
            //PersonsAttack.OnHitPersons -= Attack;
        }

        private void Start()
        {
            
            _speedPlayer = _settingsControl.GippoSpeed;
        }
        void Update()
        {
           

            _position = new Vector3(0f, SimpleInput.GetAxis("Vertical"), 0f);          // SimpleInput.GetAxis("Horizontal"),     //если нужно будет двигаться по х
           
            if (SimpleInput.GetAxis("Vertical") != 0 && _animPerson.AnimationName != "walk")
            {
                UpMove();
                //Walk();
            }
            if (SimpleInput.GetAxis("Vertical") == 0 && _animPerson.AnimationName == "walk")
            {
                Idle();
                //_animPerson.AnimationName = "idle";
            }
            transform.position += _position * Time.deltaTime * _speedPlayer;          
        }

        protected override void Idle()
        {
            base.Idle();
        }
        protected override void Walk()
        {
            base.Walk();
        }
        void HippoDeactiv()
        {
            gameObject.SetActive(false);
        }

        protected override void Attack()
        {
            base.Attack();
        }
}
}