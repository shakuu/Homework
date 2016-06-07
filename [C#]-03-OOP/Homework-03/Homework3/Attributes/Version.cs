
namespace PointAndMatrix.Attributes
{
    using System;
    
    [AttributeUsage(AttributeTargets.Struct |
                    AttributeTargets.Class | 
                    AttributeTargets.Interface,
                    AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        private int major;
        private int minor;

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        #region Properties
        private int Major
        {
            get
            {
                return this.major;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value must be positive");
                }
                else
                {
                    this.major = value;
                }
            }
        }

        private int Minor
        {
            get
            {
                return this.minor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value must be positive");
                }
                else
                {
                    this.minor = value;
                }
            }
        }

        public string Version
        {
            get
            {
                return string.Format("{0}.{1}", this.Major, this.Minor);
            }
        }
        #endregion
    }
}
