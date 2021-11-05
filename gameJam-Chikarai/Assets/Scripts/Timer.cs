using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
     [SerializeField] private float counter = 120f;
     private float _timeRemaining;
     [SerializeField] private TimerEvent timer;
     [SerializeField] private UnityEvent gameOver;

     private void Start()
     {
         _timeRemaining = counter;
     }

     void Update()
     {
         StartCoroutine(Countdown());
     }

     private IEnumerator Countdown()
     {
         if (_timeRemaining > 0 )
         {
             _timeRemaining -= Time.deltaTime;
             timer.Invoke((int) _timeRemaining);
         }

         if (_timeRemaining <= 0)
         {
             PlayerPrefs.SetInt("Result",0);
             gameOver.Invoke();
         }
         yield return _timeRemaining;
     }
     
     public void Begin()
     {
         _timeRemaining = counter;
     }
     
}