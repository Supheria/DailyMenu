﻿using DailyMenu.Flags;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DailyMenu.IO.Xml;

[XmlRoot("Member")]
public class MemberXmlSerialization : Serialization<Member>, IXmlSerialization<Member>
{
    public MemberXmlSerialization() : base("Member")
    {
    }

    public XmlSchema? GetSchema() => null;

    public void ReadXml(XmlReader reader)
    {
        Source = new()
        {
            Name = reader.GetAttribute(nameof(Source.Name)) ?? string.Empty,
            Height = reader.GetAttribute(nameof(Source.Height)).ToFloat() ?? 0f,
            Weight = reader.GetAttribute(nameof(Source.Weight)).ToFloat() ?? 0f,
            WorkIntensity = reader.GetAttribute(nameof(Source.WorkIntensity)).ToEnum<WorkIntensityFlag>(),
    };
    }

    public void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        writer.WriteAttributeString(nameof(Source.Name), Source.Name);
        writer.WriteAttributeString(nameof(Source.Height), Source.Height.ToString());
        writer.WriteAttributeString(nameof(Source.Weight), Source.Weight.ToString());
        writer.WriteAttributeString(nameof(Source.WorkIntensity), Source.WorkIntensity.ToString());
    }
}
