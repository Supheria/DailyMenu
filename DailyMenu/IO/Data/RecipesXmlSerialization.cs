using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Recipes))]
public class RecipesXmlSerialization : RosterXmlSerialization<Recipes, Recipe>
{
    public RecipesXmlSerialization() : base(nameof(Recipes), new RecipeXmlSerialization(), new())
    {

    }
}
