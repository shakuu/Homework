using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade must be a non negative number.");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade must be a non negative number.");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("maxGrade must be larger than minGrade.");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("comments must be a non empty string.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }
}
