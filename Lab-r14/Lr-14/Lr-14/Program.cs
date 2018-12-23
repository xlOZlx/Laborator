using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;


namespace Lr_14
{
    [Serializable]
    public abstract class Man
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public abstract void Naming();
    }

    [Serializable]
    [DataContract]
    public class Action : Man
    {
        int choise1;
        [DataMember]
        public bool eadinessToFight = false;

        public Action() { }

        public Action(string fName, string lName, bool eadFight)
        {
            FName = fName;
            LName = lName;
            eadinessToFight = eadFight;
        }

        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nИнформация об объекте:");
            Console.WriteLine("Имя: " + FName);
            Console.WriteLine("Фамилия: " + LName);
            if (eadinessToFight == true)
            {
                Console.WriteLine($"{FName} {LName} готов(a) к бою. ({eadinessToFight})");
            }
            else
            {
                Console.WriteLine($"{FName} {LName} не готов(a) к бою. ({eadinessToFight})\n");
            }
            Console.ResetColor();
        }

        public override void Naming()
        {
            Console.WriteLine("Name");
            FName = Console.ReadLine();
            Console.WriteLine("LastName:");
            LName = Console.ReadLine();
        }

        public void EadinessToFight()
        {
            Console.WriteLine("Готов ли человек к бою?");
            choise1 = Convert.ToInt32(Console.ReadLine());
            if (choise1 == 1)
            {
                eadinessToFight = true;
                Console.WriteLine("Человек готов к бою.");
            }
            else
            {
                eadinessToFight = false;
                Console.WriteLine("Человек не готов к бою.");
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Action action1 = new Action("Яр", "Темный", true);
            Console.WriteLine("Объект создан.");

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("action.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, action1);
                Console.WriteLine("Объект сериализован бинарно.");
            }

            using (FileStream fs = new FileStream("action.dat", FileMode.OpenOrCreate))
            {
                Action newAction1 = (Action)binaryFormatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован.");
                newAction1.Info();
            }
            Console.ReadKey();
            Console.Clear();

            Action action2 = new Action("Триас", "Ас", false);
            Console.WriteLine("Объект создан.");

            SoapFormatter soapFormatter = new SoapFormatter();

            using (FileStream fs2 = new FileStream("action.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs2, action2);
                Console.WriteLine("Объект сериализован через Soap.");
            }

            using (FileStream fs2 = new FileStream("action.soap", FileMode.OpenOrCreate))
            {
                Action newAction2 = (Action)soapFormatter.Deserialize(fs2);
                Console.WriteLine("Объект десериализован.");
                newAction2.Info();
            }
            Console.ReadKey();
            Console.Clear();

            Action action3 = new Action("Криан", "Коперников", true);
            Console.WriteLine("Объект создан.");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Action));

            using (FileStream fs3 = new FileStream("action.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs3, action3);
                Console.WriteLine("Объект сериализован через Xml.");
            }

            using (FileStream fs3 = new FileStream("action.xml", FileMode.OpenOrCreate))
            {
                Action newAction3 = (Action)xmlSerializer.Deserialize(fs3);
                Console.WriteLine("Объект десериализован.");
                newAction3.Info();
            }
            Console.ReadKey();
            Console.Clear();

            Action[] actions = new[] { action1, action2, action3 };
            Console.WriteLine("Массив создан.");

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Action[]));

            using (FileStream fs4 = new FileStream("actions.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs4, actions);
                Console.WriteLine("Массив сериалзован через Json.");
            }

            using (FileStream fs4 = new FileStream("actions.json", FileMode.OpenOrCreate))
            {
                Action[] newActions = (Action[])jsonFormatter.ReadObject(fs4);
                Console.WriteLine("Массив десериализован.");
                foreach (Action a in newActions)
                {
                    a.Info();
                }
            }
            Console.ReadLine();
            Console.Clear();

            /*====================================================================*/
            ////////////////////////////////////////////////////////////////////////
            ///////////////////////////    ЗАДАНИЕ 3    ////////////////////////////
            ////////////////////////////////////////////////////////////////////////
            /*====================================================================*/


            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(Action[]));

            using (FileStream fs5 = new FileStream("action2.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer2.Serialize(fs5, actions);
                Console.WriteLine("Массив сериализован через Xml.");
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("action2.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodeList = xRoot.SelectNodes("*");

            Console.WriteLine("Первый запрос: ");
            foreach (XmlNode n in nodeList)
            {
                Console.WriteLine(n.OuterXml);
            }

            XmlNodeList childNodes = xRoot.SelectNodes("//Action/FName");
            Console.WriteLine("Второй запрос: ");
            foreach(XmlNode n in childNodes)
            {
                Console.WriteLine(n.InnerText);
            }
            Console.ReadLine();
            Console.Clear();

            /*====================================================================*/
            ////////////////////////////////////////////////////////////////////////
            ///////////////////////////    ЗАДАНИЕ 4    ////////////////////////////
            ////////////////////////////////////////////////////////////////////////
            /*====================================================================*/

            XDocument xdoc = new XDocument(new XElement("phones",
                new XElement("phone", new XAttribute("name", "iPhone X"),
                new XElement("company", "Apple"), new XElement("price", "45000")),
                new XElement("phone", new XAttribute("name", "Samsung Galaxy S8"),
                new XElement("company", "Samsung"), new XElement("price", "30000"))));
            xdoc.Save("1phones.xml");
            XDocument xmldoc = XDocument.Load("1phones.xml");
            Console.WriteLine("Первый запрос через Linq to Xml:\n");
            foreach (XElement phoneElement in xmldoc.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");
                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine("Phone: {0}", nameAttribute.Value);
                    Console.WriteLine("Company: {0}", companyElement.Value);
                    Console.WriteLine("Price: {0}", priceElement.Value);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nВторой запрос через Linq to Xml:\n");
            foreach (XElement phoneElement in xmldoc.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");
                if (nameAttribute != null && companyElement != null && priceElement.Value == "30000")
                {
                    Console.WriteLine("Phone: {0}", nameAttribute.Value);
                    Console.WriteLine("Company: {0}", companyElement.Value);
                    Console.WriteLine("Price: {0}", priceElement.Value);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
