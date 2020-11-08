using System;
using System.Dynamic;
using System.Xml.Linq;

namespace DynamicForXMLParsing
{

    public class DynamicXMLNode:DynamicObject
    {
        private XElement node;
        public DynamicXMLNode(XElement node)
        {
            this.node = node;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var element = node.Element(binder.Name);
            if (element!=null)
            {
                result = new DynamicXMLNode(element);
                return true;
            }
            else
            {
                var attribute = node.Attribute(binder.Name);
                if (attribute!=null)
                {
                    result = attribute.Value;
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var xml = @"
                <people>
                    <person name='Philip' />
                    <person name='Helen' />
                </people>
                ";
            var node = XElement.Parse(xml);
            var name = node.Element("person").Attribute("name");
            Console.WriteLine(name?.Value);

            dynamic dyn = new DynamicXMLNode(node);
            Console.WriteLine(dyn.person.name);
        }
    }
}
