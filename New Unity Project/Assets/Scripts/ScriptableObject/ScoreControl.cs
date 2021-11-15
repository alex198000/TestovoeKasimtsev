using UnityEngine;

namespace Game
{

    [CreateAssetMenu(fileName = "ScoreControl", menuName = "ScriptableObjects/NewScoreControl")]
    public class ScoreControl : ScriptableObject
    {
        [SerializeField] private int _score;
        [SerializeField] private int _scoreWin;  

        public int Score { get { return _score; } set { _score = value; } }

        public int ScoreWin { get => _scoreWin; set => _scoreWin = value; }

        public void OnEnable()
        {
            Score = 0;
        }
    }
}