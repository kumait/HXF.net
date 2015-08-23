using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXF.Util
{
    public class Conf
    {
        public string ConnectionString { get; set; }
        public string Schema { get; set; }
        public string DALPath { get; set; }
        public bool UseCSNaming { get; set; }
        public bool UseWebService { get; set; }
        public string ServiceUrl { get; set; }
        public string ProxyLocation { get; set; }
        public string Platform { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Conf conf = obj as Conf;
            if (conf == null)
            {
                return false;
            }

            bool eq =
                this.ConnectionString == conf.ConnectionString &&
                this.Schema == conf.Schema &&
                this.DALPath == conf.DALPath &&
                this.UseCSNaming == conf.UseCSNaming &&
                this.UseWebService == conf.UseWebService &&
                this.ServiceUrl == conf.ServiceUrl &&
                this.ProxyLocation == conf.ProxyLocation &&
                this.Platform == conf.Platform;
            return eq;
        }

        public bool isEmpty()
        {
            bool em =
                string.IsNullOrEmpty(ConnectionString) &&
                string.IsNullOrEmpty(Schema) &&
                string.IsNullOrEmpty(DALPath) &&
                string.IsNullOrEmpty(ServiceUrl) &&
                string.IsNullOrEmpty(ProxyLocation) &&
                string.IsNullOrEmpty(Platform);
            return em;
                
        }
    }
}
