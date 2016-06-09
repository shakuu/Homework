
namespace SchoolClasses.Disciplines
{
    using System;
    using Interfaces;
    using Enumerators;
    using Validation.ValidateStrings;

    public class Discipline : ICommentable
    {
        #region Constants ( for validation )
        /// <summary>
        /// Min - Max number of Classes
        /// </summary>
        private const int MaxNumberOfLectures = 20;
        private const int MinNumberOfLectures = 1;
        private const int MaxNumberOfExercises = 50;
        private const int MinNumberOfExercises = 0;
        #endregion

        private DisciplineType name;
        private string comment;
        private int lectures;
        private int exercises;

        public Discipline(DisciplineType name,
            int numberLectures,
            int numberExercises = 0)
        {
            this.Name = name;
            this.NumberOfLectures = numberLectures;
            this.NumberOfExcercises = numberExercises;
        }

        #region Properties
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                ValidateString.ValidateComment(value);
                this.comment = value;
            }
        }

        public DisciplineType Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.lectures;
            }
            set
            {
                if (!(MinNumberOfLectures <= value && value <= MaxNumberOfLectures))
                {
                    throw new ArgumentException
                        (string.Format("Number of Exercises must be in the range {0} - {1}",
                            MinNumberOfLectures, MaxNumberOfLectures));
                }
                this.lectures = value;
            }
        }

        public int NumberOfExcercises
        {
            get
            {
                return this.exercises;
            }
            set
            {
                if (!(MinNumberOfExercises <= value && value <= MaxNumberOfExercises))
                {
                    throw new ArgumentException
                        (string.Format("Number of Exercises must be in the range {0} - {1}",
                            MinNumberOfExercises, MaxNumberOfExercises));
                }
                else
                {
                    this.exercises = value;
                }
            }
        }
        #endregion
    }
}
