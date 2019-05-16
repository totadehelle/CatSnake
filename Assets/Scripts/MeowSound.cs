using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MeowSound : MonoBehaviour
{
        public AudioClip meow;
        
        private AudioSource source;
    
        void Awake () {
            source = GetComponent<AudioSource>();
        }
    
    
        void OnTriggerEnter2D(Collider2D coll) {
            // Food?
            if(coll.gameObject.CompareTag(EnumsSet.Tags.Food.ToString())
            || coll.gameObject.CompareTag(EnumsSet.Tags.Bonus.ToString())){
                source.PlayOneShot(meow);
            }
        }

}
