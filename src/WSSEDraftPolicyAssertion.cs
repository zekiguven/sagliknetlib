using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3;
using System.Xml;

namespace SaglikNetLib
{
    class WSSEDraftPolicyAssertion : PolicyAssertion
    {
        public override Microsoft.Web.Services3.SoapFilter CreateServiceInputFilter(FilterCreationContext context)
        {
            return null;
        }

        public override Microsoft.Web.Services3.SoapFilter CreateServiceOutputFilter(FilterCreationContext context)
        {
            return null;
        }

        public override Microsoft.Web.Services3.SoapFilter CreateClientInputFilter(FilterCreationContext context)
        {
            return null;
        }

        public override Microsoft.Web.Services3.SoapFilter CreateClientOutputFilter(FilterCreationContext context)
        {
            return new WSSEDraftClientOutputFilter();
        }

        public override void ReadXml(XmlReader reader,IDictionary<string, Type> extensions)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (extensions == null)
                throw new ArgumentNullException("extensions");

            bool isEmpty = reader.IsEmptyElement;

            reader.ReadStartElement("WSSEDraftAssertion");
            if (!isEmpty)
            {
                reader.Skip();
            }
        }

        public override IEnumerable<KeyValuePair<string, Type>> GetExtensions()
        {
            return new KeyValuePair<string, Type>[] { new KeyValuePair<string, Type>("WSSEDraftAssertion", this.GetType()) };
        } 
    }

    class WSSEDraftClientOutputFilter : SoapFilter 
    { 
        internal WSSEDraftClientOutputFilter() 
        { 
        } 
 
        public override SoapFilterResult ProcessMessage(SoapEnvelope envelope) 
        { 
            XmlNodeList nodeList = envelope.Header.GetElementsByTagName("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");             XmlNode node = nodeList.Item(0); 
            XmlAttributeCollection attributes = node.Attributes; 
            attributes.RemoveAll(); 
            return SoapFilterResult.Continue; 
        } 
    }
}
