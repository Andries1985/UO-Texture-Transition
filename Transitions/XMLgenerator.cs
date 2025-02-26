using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Transitions;

public class XMLgenerator
{
    private static readonly List<string> AllowedAlphaTypes = new()
        { "A_DR", "A_DL", "A_UU", "A_LL", "A_UR", "A_UL", "B_UL", "B_UR", "B_DR", "B_DL", "B_UU", "B_LL" };

    public static string? InitialLandTypeId { get; set; }


    public void GenerateXML(List<string> texture1FilePaths, List<string> texture2FilePaths,
        List<string> alphaImageFileNames, string outputPath, string nameTextureA, string brushIdA, string nameTextureB,
        string brushIdB)

    {
        var xmlDocument = new XDocument(new XElement("transition"));

        var currentID = InitialLandTypeId; // Déclaré en dehors de l'appel à GenerateXML

        GenerateBrush(xmlDocument, nameTextureA, nameTextureB, ref currentID, texture1FilePaths,
            alphaImageFileNames.Where(x => x.Contains("A_")).ToList(), brushIdB, nameTextureB, brushIdA);
        GenerateBrush(xmlDocument, brushIdA, brushIdB, ref currentID, texture2FilePaths,
            alphaImageFileNames.Where(x => x.Contains("B_")).ToList(), nameTextureB, nameTextureA, nameTextureA);


        var xmlFilePath = Path.Combine(outputPath, "transition.xml");
        xmlDocument.Save(xmlFilePath);

        Console.WriteLine($"XML file was generated successfully : {xmlFilePath}");
    }

    private static void GenerateBrush(XDocument xmlDocument, string brushName, string brushId, ref string currentID,
        List<string> textureFilePaths, List<string> alphaImageFileNames, string oppositeBrushId, string nameTextureB,
        string nameTextureA)
    {
        if (xmlDocument.Root != null)
        {
            var brushElement = new XElement("Brush",
                new XAttribute("Id", brushId),
                new XAttribute("Name", brushName));

            foreach (var filePath in textureFilePaths)
            {
                var textureName = Path.GetFileNameWithoutExtension(filePath);
                var hexValue = ExtractHexNumber(textureName);

                var landElement = new XElement("Land",
                    new XAttribute("ID", $"{hexValue}"));
                brushElement.Add(landElement);
            }

            var nextID = IncrementHexID(currentID);
            var isFirstTextureA = true; // Initialisez isFirstTextureA à true ou false en fonction de votre logique

            var edgeElement = new XElement("Edge");
            edgeElement.SetAttributeValue("To", oppositeBrushId);
            edgeElement.Add(new XComment($"{(isFirstTextureA ? nameTextureA : nameTextureB)}"));


            foreach (var alphaFileName in alphaImageFileNames)
            {
                var alphaName = Path.GetFileNameWithoutExtension(alphaFileName);
                var alphaType = ExtractAlphaType(alphaName);
                var hexValue = ExtractHexNumber(alphaName);

                // Supprimer les préfixes "A_" et "B_" de la valeur alphaType
                if (alphaType.StartsWith("A_") || alphaType.StartsWith("B_"))
                    alphaType = alphaType.Substring(2); // Supprimer les deux premiers caractères (le préfixe)

                // Créer l'élément <Land> en spécifiant l'attribut "Type" avec la valeur alphaType modifiée
                var landElement = new XElement("Land",
                    new XAttribute("Type", alphaType),
                    new XAttribute("ID", $"0x{currentID}"));

                edgeElement.Add(landElement);

                currentID = IncrementHexID(currentID);
            }

            brushElement.Add(edgeElement);
            xmlDocument.Root.Add(brushElement);
        }
        else
        {
            Console.WriteLine("Warning: xmlDocument.Root is null. Check the correct loading of the XML document.");
        }
    }


    private static string ExtractHexNumber(string fileName)
    {
        return Regex.Match(fileName, @"\b0x[0-9a-fA-F]+\b").Value;
    }


    private static string ExtractAlphaType(string fileName)
    {
        var alphaType = fileName.Substring(0, 4);

        return AllowedAlphaTypes.Contains(alphaType) ? alphaType : "Unknown";
    }


    private static string IncrementHexID(string currentID)
    {
        // Convertir l'ID actuel en entier
        var intValue = Convert.ToInt32(currentID, 16);

        // Incrémenter l'entier de 1
        intValue++;

        // Convertir cet entier en représentation hexadécimale avec un format spécifique de 4 chiffres
        var nextHexID = intValue.ToString("X4");

        return nextHexID;
    }
}