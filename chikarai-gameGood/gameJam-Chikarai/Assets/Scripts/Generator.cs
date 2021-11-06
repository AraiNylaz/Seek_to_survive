using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    private bool _isCharged;
    [SerializeField] private float timeToHold = 3f;
    private float _timeHeld;
    [SerializeField] private UnityEvent isCompleted;
    [SerializeField] private UnityEvent completing;
    [SerializeField] private Slider progress;

    private void Start()
    {
        _isCharged = false;
        _timeHeld = 0f;
    }


    public void ChargeGenerator(float time)
    {
        if (_isCharged)
            return;
        
        if(_timeHeld >= timeToHold) Debug.Log("Already charged");
        _timeHeld += Mathf.Floor(time);

        PlayerPrefs.SetFloat("time",time);
        completing.Invoke();


        if (_timeHeld >= timeToHold)
        {
            _isCharged = true;
            isCompleted.Invoke();
        }
    }
}