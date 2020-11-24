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

        public override char GetLetterGrade(double averageGrade)
        {
            int studentsGreaterThenInput = 0;
            char letterGrade = 'F';
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
                //throw new InvalidOperationException("Less then five students are in the supplied Gradebook");
            }
            else
            {
                foreach (var student in Students)
                {
                    if (student.AverageGrade > averageGrade)
                    {
                        studentsGreaterThenInput++;
                    }
                }
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
