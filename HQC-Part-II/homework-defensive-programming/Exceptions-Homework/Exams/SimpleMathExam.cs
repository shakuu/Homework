using System;

public class SimpleMathExam : Exam
{
    public SimpleMathExam(int problemsSolved)
    {
        var isValidNumberOfProblems = 0 <= problemsSolved && problemsSolved <= 2;
        if (!isValidNumberOfProblems)
        {
            throw new ArgumentOutOfRangeException("Invalid number of problems.");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
