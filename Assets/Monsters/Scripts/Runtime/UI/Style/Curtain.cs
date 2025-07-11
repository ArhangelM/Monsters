using DG.Tweening;
using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.UI.Style
{
    internal class Curtain : MonoBehaviour
    {
        [SerializeField] private GameObject _top;
        [SerializeField] private GameObject _down;
        [SerializeField] private GameObject _left;
        [SerializeField] private GameObject _right;

        private Sequence _sequence;
        private Vector2 _centerInPixels;

        private void Awake()
        {
            GetCenterScreen();
            InitSequence();
        }

        private void Start()
        {
            _sequence.Play();
        }

        private void InitSequence()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(_top.transform.DOLocalMoveY(_down.transform.position.y, 2f).SetEase(Ease.InSine))
                     .Join(_down.transform.DOLocalMoveY(_top.transform.position.y, 2f).SetEase(Ease.InSine))
                     .Join(_left.transform.DOLocalMoveX(_right.transform.position.x, 2f).SetEase(Ease.InSine))
                     .Join(_right.transform.DOLocalMoveX(_left.transform.position.x, 2f).SetEase(Ease.InSine));

            _sequence.OnComplete(() =>
            {
                Debug.Log("Curtain animation completed.");
                FinishPosition();
            });
        }

        private void FinishPosition()
        {
            _top.transform.localPosition = new Vector3(_centerInPixels.x, _centerInPixels.y, 0f);
            _down.transform.localPosition = new Vector3(_centerInPixels.x, _centerInPixels.y, 0f);
            _left.transform.localPosition = new Vector3(_centerInPixels.x, _centerInPixels.y, 0f);
            _right.transform.localPosition = new Vector3(_centerInPixels.x, _centerInPixels.y, 0f);
        }

        private void GetCenterScreen()
        {
            _centerInPixels = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        }
    }
}
