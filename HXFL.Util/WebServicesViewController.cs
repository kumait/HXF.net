using HXF.WebServices;
using HXF.WebServices.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Util
{
    public class PlatformInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


    public class WebServicesViewController
    {
        private List<PlatformInfo> getPlatforms()
        {
            List<PlatformInfo> platforms = new List<PlatformInfo>();
            platforms.Add(new PlatformInfo() { Id = "csharp", Name = "C#" });
            platforms.Add(new PlatformInfo() { Id = "java", Name = "Java" });
            platforms.Add(new PlatformInfo() { Id = "objc", Name = "Objective C" });
            platforms.Add(new PlatformInfo() { Id = "js-angularjs", Name = "JavaScript/Angular" });
            platforms.Add(new PlatformInfo() { Id = "js-dojo", Name = "JavaScript/Dojo" });
            platforms.Add(new PlatformInfo() { Id = "js-dojo-amd", Name = "JavaScript/Dojo (AMD)" });
            platforms.Add(new PlatformInfo() { Id = "flex", Name = "Flex" });

            return platforms;
        }

        public List<PlatformInfo> Platforms
        {
            get
            {
                return getPlatforms();
            }
        }
    }
}
