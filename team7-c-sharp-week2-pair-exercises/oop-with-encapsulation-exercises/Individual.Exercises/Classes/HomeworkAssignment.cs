using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        private int totalMarks;
        private int possibleMarks;
        private string submitterName;
        private string letterGrade;

        public int TotalMarks
        {
            get
            {
                return totalMarks;
            }
            set
            {
                totalMarks = value;
            }
        }

        public int PossibleMarks
        {
            get
            {
                return possibleMarks;
            }
        }

        public string SubmitterName { get; }

        public string LetterGrade
        {
            get
            {
                string grade = "";
              double percentage = (double)totalMarks / (double)possibleMarks;        
                if (percentage >= .90)
                {
                    grade = "A";
                    return grade;
                }
                if (percentage >= 0.8 && percentage < 0.9)
                {
                    grade = "B";
                    return grade;
                }
                if (percentage >= .7 && percentage < .8)
                {
                    grade = "C";
                    return grade;
                }
                if (percentage >= 0.6 && percentage < 0.7)
                {
                    grade = "D";
                    return grade;
                }
                if (percentage < 0.6)
                {
                    grade = "F";
                    return grade;
                }
                return grade;
            }
        }

        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            this.possibleMarks = possibleMarks;
            this.submitterName = submitterName;
        }
    }
}
