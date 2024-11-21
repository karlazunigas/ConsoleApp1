using System;
using System.Threading;

class Program
{
    public class Client
    {
        public string product { get; set; }
        public int expectedS { get; set; }
        public int actualS { get; set; }

        public bool matchingPrice
        {
            get
            {
                return expectedS == actualS;
            }
        }
    }

    static void insertR(Client client)
    {
        Console.WriteLine($"Cotización para el producto: {client.product}");

       
        Console.WriteLine("Precio Supuesto: ");
        client.expectedS = int.Parse(Console.ReadLine());

       
        Console.Write("Precio actual: ");
        client.actualS = int.Parse(Console.ReadLine());

        if (client.matchingPrice)
        {
            Console.WriteLine("Precio Correcto");
        }
        else
        {
            Console.WriteLine("Precio Erróneo");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Cantidad de productos a cotizar");
        int quantity = int.Parse(Console.ReadLine());

        Client[] clients = new Client[quantity];


        for (int i = 0; i < quantity; i++)
        {
            Console.WriteLine($"Producto #{i + 1} ");
            string producto = Console.ReadLine();

            clients[i] = new Client { product = producto };

           
            Thread hilo = new Thread(() => insertR(clients[i]));
            hilo.Start();
            hilo.Join(); 
        }

        Console.WriteLine("Todos los resultados han sido ingresados.");
    }
}