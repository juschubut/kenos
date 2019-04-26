//
// XmlNodeExtensions.cs:
//
// Author:
//   Ruben Vermeersch (ruben@savanne.be)
//
// Copyright (C) 2009 Ruben Vermeersch
//
// This library is free software; you can redistribute it and/or modify
// it  under the terms of the GNU Lesser General Public License version
// 2.1 as published by the Free Software Foundation.
//
// This library is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307
// USA
//

using System;
using System.Collections.Generic;
using System.Xml;

namespace Kenos.TagsLib.TagLib.Xmp
{
    internal class XmlNodeExtensions
    {
        public static bool In(XmlNode node, string ns)
        {
            return node.NamespaceURI == ns;
        }

        public static bool Is(XmlNode node, string ns, string name)
        {
            return In(node, ns) && node.LocalName == name;
        }

        // 7.2.2 coreSyntaxTerms
        //		rdf:RDF | rdf:ID | rdf:about | rdf:parseType | rdf:resource | rdf:nodeID | rdf:datatype
        public static bool IsCoreSyntax(XmlNode node)
        {
            return In(node, XmpTag.RDF_NS) && (
                node.LocalName == XmpTag.RDF_URI ||
                node.LocalName == XmpTag.ID_URI ||
                node.LocalName == XmpTag.ABOUT_URI ||
                node.LocalName == XmpTag.PARSE_TYPE_URI ||
                node.LocalName == XmpTag.RESOURCE_URI ||
                node.LocalName == XmpTag.NODE_ID_URI ||
                node.LocalName == XmpTag.DATA_TYPE_URI
                    );
        }

        // 7.2.4 oldTerms
        //		rdf:aboutEach | rdf:aboutEachPrefix | rdf:bagID
        public static bool IsOld(XmlNode node)
        {
            return In(node, XmpTag.RDF_NS) && (
                node.LocalName == XmpTag.ABOUT_EACH_URI ||
                node.LocalName == XmpTag.ABOUT_EACH_PREFIX_URI ||
                node.LocalName == XmpTag.BAG_ID_URI
                );
        }

        // 7.2.5 nodeElementURIs
        //		anyURI - ( coreSyntaxTerms | rdf:li | oldTerms )
        public static bool IsNodeElement(XmlNode node)
        {
            return !IsCoreSyntax(node) &&
                !Is(node, XmpTag.RDF_NS, XmpTag.LI_URI) &&
                !IsOld(node);
        }

        // 7.2.6 propertyElementURIs
        //		anyURI - ( coreSyntaxTerms | rdf:Description | oldTerms )
        public static bool IsPropertyElement(XmlNode node)
        {
            return !IsCoreSyntax(node) &&
                !Is(node, XmpTag.RDF_NS, XmpTag.DESCRIPTION_URI) &&
                !IsOld(node);
        }

        // 7.2.7 propertyAttributeURIs
        //		anyURI - ( coreSyntaxTerms | rdf:Description | rdf:li | oldTerms )
        public static bool IsPropertyAttribute(XmlNode node)
        {
            return node is XmlAttribute &&
                !IsCoreSyntax(node) &&
                !Is(node, XmpTag.RDF_NS, XmpTag.DESCRIPTION_URI) &&
                !Is(node, XmpTag.RDF_NS, XmpTag.LI_URI) &&
                !IsOld(node);
        }
    }
}
