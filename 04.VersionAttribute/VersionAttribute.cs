using System;

namespace _04.VersionAttribute
{
    [AttributeUsage(AttributeTargets.Class |
    AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Enum | AttributeTargets.Method,
    Inherited = false, AllowMultiple = false)]
    public sealed class VersionAttribute : Attribute
    {
        private int
            majorBuild,
            minorBuild;

        public VersionAttribute(int majorBuild, int minorBuild)
        {
            this.majorBuild = majorBuild;
            this.minorBuild = minorBuild;
        }

        public string Build
        {
            get 
            { 
                return string.Format("{0}.{1}", 
                    this.majorBuild, this.minorBuild); 
            }
        }

        public int MajorBuild
        {
            get { return this.majorBuild; }
        }

        public int MinorBuild
        {
            get { return this.minorBuild; }
        }

    }
}
