using HXF.Common;
using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Generators
{
    public class ObjectiveCGenerator: IProxyGenerator
    {
        private const string HEADER = @"
// HXF.WebServices Generated Code
";
        private const string INIT = @"
- (id) init
{
    self = [super init];
    if (self) {
        //[self setUrl: [NSURL URLWithString: @""""]];
    }
    return self;
}";    
        private const string LOAD = @"
- (void)load:(NSData*)data completionHandler:(void(^)(NSURLResponse *response, NSData *data, NSError *error))handler
{
    NSString *s = [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
    NSLog(@""Loading... %@"", s);
    
    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:url];
    [request setHTTPMethod:@""POST""];
    [request setHTTPBody:data];
    NSOperationQueue *queue = [[NSOperationQueue alloc] init];
    [NSURLConnection sendAsynchronousRequest:request queue:queue
                           completionHandler:handler];
}";     
        private const string CALL = @"
NSData *data = [NSJSONSerialization dataWithJSONObject:d options:0 error:nil];
[self load:data completionHandler:^(NSURLResponse *response, NSData *data, NSError *error) {
    NSLog(@""done"");
    NSString *s = [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
    NSLog(@""RAW response = %@"", s);
    NSDictionary *d = [NSJSONSerialization JSONObjectWithData:data options:0 error:nil];
    handler(d, error);
}];";

        public ObjectiveCGenerator(TypeMap typeMap)
        {
            this.TypeMap = typeMap;
        }

        public ObjectiveCGenerator() : this(null) { }

        public IDictionary<string, string> Generate(Service service)
        {
            IDictionary<string, string> files = new Dictionary<string, string>();
            foreach (Interface intr in service.Interfaces)
            {
                string ofile = intr.Name + ".h";
                string mfile = intr.Name + ".m";
                files[ofile] = GenerateH(service, intr);
                files[mfile] = GenerateM(service, intr);
            }

            return files;
        }

        public string GenerateH(Service service, Interface intr)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine(HEADER);
            writer.WriteLine("#import <Foundation/Foundation.h>");
            writer.WriteLine();
            writer.WriteLineFormat("@interface {0}: NSObject", intr.Name);
            writer.WriteLine();
            writer.WriteLine("@property (nonatomic, strong) NSURL *url;");
            writer.WriteLine("@property (nonatomic, strong) NSString *interface;");
            writer.WriteLine();
            foreach (Method method in intr.Methods)
            {
                writer.Write(GenerateMethodHeader(intr, method));
                writer.WriteLineNoIdent(";");
            }
            writer.WriteLine();
            writer.WriteLine("@end");
            return writer.Code;
        }

        public string GenerateM(Service service, Interface intr)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine(HEADER);
            writer.WriteLineFormat("#import \"{0}.h\"", intr.Name);
            writer.WriteLine();
            writer.WriteLineFormat("@implementation {0}", intr.Name);
            writer.WriteLine();
            writer.WriteLine("@synthesize url;");
            writer.WriteLine("@synthesize interface;");
            writer.WriteLine(INIT);
            writer.WriteLine();
            writer.WriteLine(LOAD);
            writer.WriteLine();
            foreach (Method method in intr.Methods)
            {
                writer.WriteLine(GenerateMethodHeader(intr, method));
                writer.WriteLine("{");
                writer.PushIdent();
                writer.WriteLine(GenerateMethodBody(intr, method));
                writer.PopIdent();
                writer.WriteLine("}");
                writer.WriteLine();
            }
            writer.WriteLine();
            writer.WriteLine("@end");
            return writer.Code;
        }

        

        public string GenerateMethodHeader(Interface intr, Method method)
        {
            string pheader = "";
            string blockParameter = "(void(^)(NSDictionary *dictionary, NSError *error))handler";
            for (int i = 0; i < method.Parameters.Count; i++)
            {
                Parameter p = method.Parameters[i];
                string mappedType = TypeMap == null ? p.Type : TypeMap.MapDataType(p.Type);
                string s = "";
                if (i == 0)
                {
                    s = string.Format(":({0})a{1}", mappedType, p.Name);
                }
                else
                {
                    s = string.Format(" {1}:({0})a{1}", mappedType, p.Name);
                }
                pheader += s;
            }

            if (method.Parameters.Count == 0)
            {
                string s = string.Format(":{0}", blockParameter);
                pheader += s;
            }
            else
            {
                string s = string.Format(" completionHanlder:{0}", blockParameter);
                pheader += s;
            }

            string mheader = string.Format("-(void) {0}{1}", method.Name, pheader);
            return mheader;
        }

        public string GenerateMethodBody(Interface intr, Method method)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine("NSMutableDictionary *d = [[NSMutableDictionary alloc] init];");
            writer.WriteLineFormat("[d setValue:@\"{0}\" forKey:@\"interface\"];", intr.Name);
            writer.WriteLineFormat("[d setValue:@\"{0}\" forKey:@\"method\"];", method.Name);
            if (method.Parameters.Count > 0)
            {
                writer.WriteLine("NSMutableDictionary *p = [[NSMutableDictionary alloc] init];");
                for (int i = 0; i < method.Parameters.Count; i++)
                {
                    Parameter p = method.Parameters[i];
                    writer.WriteLineFormat("[p setValue:a{0} forKey:@\"{0}\"];", p.Name);
                }
                writer.WriteLineFormat("[d setValue:p forKey:@\"parameters\"];", method.Name);
            }
            writer.WriteLine(CALL);
            return writer.Code;
        }

        public string GetPlatform()
        {
            return "OBJC";
        }

        public string GetName()
        {
            return "Objective C Standard Generator";
        }

        public TypeMap TypeMap { get; set; }
    }
}
