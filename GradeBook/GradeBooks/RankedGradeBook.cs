using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            { 
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentsGreaterThenInput = 0;
            char letterGrade = 'F';
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {
                foreach (var student in Students)                
                    if (student.AverageGrade > averageGrade)                    
                        studentsGreaterThenInput++;                    
                
                var twentyPercent = (double)(Students.Count * 0.20);

                if (studentsGreaterThenInput < twentyPercent)
                    letterGrade = 'A';
                else if (studentsGreaterThenInput < (twentyPercent * 2))
                    letterGrade = 'B';
                else if (studentsGreaterThenInput < (twentyPercent * 3))
                    letterGrade = 'C';
                else if (studentsGreaterThenInput < (twentyPercent * 4))
                    letterGrade = 'D';
                else
                    letterGrade = 'F';
            }                     

            return letterGrade;
        }
    }
}
