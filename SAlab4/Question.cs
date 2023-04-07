﻿using System.Collections.Generic;

namespace SAlab4
{
    public class Question
    {
        public int id { get; set; }
        public string Quest { get; set; }
        public List<string> answer1 { get; set; }
        public List<string> answer2 { get; set; }
        public List<string> answer3 { get; set; }
        public bool isActive { get; set; }
        public List<Comment> comments { get; set; } 
        public List<string> emailsForCheck { get; set; }
        public List<Answer> answers { get; set; }

        public Question()
        {
            id = 0;
            answer1 = new List<string>();
            answer2 = new List<string>();
            answer3 = new List<string>();
            emailsForCheck = new List<string>();
            Quest = "";
            isActive = false;
            answers = new List<Answer>();
            comments = new List<Comment>();
        }

       public Question(string quest, List<string> answer1, List<string> answer2, List<string> answer3)
       {
            Quest = quest;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.isActive = isActive;
            emailsForCheck = new List<string>();
            comments = new List<Comment>();
            answers = new List<Answer>();
            isActive = false;
        }
    }
}
