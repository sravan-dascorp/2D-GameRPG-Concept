using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]public class Conversationclass 
{



    [SerializeField] int conversationindex;
        public string Conversation_text;

        public string reply1;
        public int reply1conversation;
        public string reply2;
        public int reply2conversation;


    public bool endconversation;

    public bool gotoQuestion;

    public bool reward_player;
    public string rewarditem;
    public float gold_value;

    public bool changebooltrigger;
    public Booltrigger booltriggerscript;


}
