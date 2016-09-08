using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client;
using Client.EmployeeService;
using System.Runtime.Serialization;

namespace ClientWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeServiceClient client = new EmployeeServiceClient();
            var x = client.GetEmployee(1);

            Console.WriteLine(x.Id);
            Console.WriteLine(x.Name);
            Console.WriteLine(x.DateOfBirth);
            Console.WriteLine(x.Gender);

            Console.ReadKey();

            Employee emp = new Employee() { Id = 4, Name = "Nikhil", DateOfBirth = DateTime.Now, Gender = "Male" };
            client.SaveEmployee(emp);
        }


            public static class Serializer
        {
            public static string Serialize(Object ob)
            {
                using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
                {
                    DataContractSerializer serializer = new DataContractSerializer(ob.GetType());
                    {
                        serializer.WriteObject(memory, ob);
                        return Encoding.UTF8.GetString(memory.ToArray());
                    }

                }

            }
        }


        public static class Deserializer
        {
            public static T Deserialize<T>(string data)
            {
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));

                return (T)deserializer.ReadObject(System.Xml.XmlReader.Create(new System.IO.StringReader(data)));
            }
        }

    }

  }

