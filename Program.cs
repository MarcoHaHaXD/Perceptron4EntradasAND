using System;
using System.Collections.Generic;
namespace Perceptron4
{
    class Program
    {
        public List<Neurona> tabla = new List<Neurona>();//lista de Neuronas, seria como la tabla de verdad
        public Neurona neurona;
        public Double[] xs;
        public Double dx;
        public Random rnd = new Random();
        public double w1, w2, w3, w4, u;
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Principal();
            
        }
        public void Principal()
        {
            Inicio();//llamamos al metodo inicio
            Console.WriteLine("tabla de entradas");
            Console.WriteLine("x1\tx2\tx3\tx4\tY");
            foreach (var e in tabla)
            {
                Console.WriteLine(e.x[0].ToString() + "\t" + e.x[1].ToString() + "\t" + e.x[2].ToString() + "\t" + e.x[3].ToString() + "\t" + e.dx);
            }
            Console.WriteLine("valores iniciales");
            Console.WriteLine("w1=" + w1.ToString() + ", " + "w2=" + w2.ToString() + ", " + "w3=" + w3.ToString() + ", " + "w4=" + w4.ToString() + ", ");
            Console.WriteLine("u=" + u.ToString());
            int b = 0;//contador inicializado en 0
            do//hacer hasta
            {
                foreach (Neurona a in tabla)
                {
                    b = Calc(a, b);//ir a metodo calcular
                }
            } while (b == tabla.Count);//que contador sea igual a el numero de elemntos en la lista 
            //Console.WriteLine("Hello World!");
            Console.WriteLine("valores finales");
            Console.WriteLine("w1=" + w1.ToString() + ", " + "w2=" + w2.ToString() + ", " + "w3=" + w3.ToString() + ", " + "w4=" + w4.ToString() + ", ");
            Console.WriteLine("u=" + u.ToString());
            Console.ReadKey();
        }
        public void Inicio()//el metodo inicio agraga a nuestra lista tabla los valores de la Clase neurona
        {
            //agregara a tabala nueva neurona (entradas xs iguales a nueva array{valores de la array}, dx}
            //la array contiene  nuestras entradas x
            tabla.Add(neurona = new Neurona(xs = new double[] { -1, -1, -1, -1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { -1, -1, -1, 1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { -1, -1, 1, -1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { -1, -1, 1, 1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { -1, 1, -1, -1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { -1, 1, -1, 1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { -1, 1, 1, -1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { -1, 1, 1, 1 }, dx = -1));

            tabla.Add(neurona = new Neurona(xs = new double[] { 1, -1, -1, -1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { 1, -1, -1, 1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { 1, -1, 1, -1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { 1, -1, 1, 1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { 1, 1, -1, -1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { 1, 1, -1, 1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { 1, 1, 1, -1 }, dx = -1));
            tabla.Add(neurona = new Neurona(xs = new double[] { 1, 1, 1, 1 }, dx = 1));
            double n,n2,n3,n4,um;
            //solicita ingresar cualquier numero el cuel se le asignara a nuestros pesos y el umbral
            Console.WriteLine("ingrese valor aleatoria para los pesos y el umbral");
            Console.WriteLine("ingrese valor del peso 1");
            n = double.Parse(Console.ReadLine());
            Console.WriteLine("ingrese valor del peso 2");
            n2 = double.Parse(Console.ReadLine());
            Console.WriteLine("ingrese valor del peso 3");
            n3 = double.Parse(Console.ReadLine());
            Console.WriteLine("ingrese valor del peso 4");
            n4 = double.Parse(Console.ReadLine());
            Console.WriteLine("ingrese valor del umbral");
            um = double.Parse(Console.ReadLine());
            w1 = n;
            w2 = n2;
            w3 = n3;
            w4 = n4;
            u = um ;
            Console.Clear();//limpia la consola
        }
        public int Calc(Neurona a, int b)//metodo para calular, recibe una neurona y el valor de nuestro contador
        {
            int y;//variable "Y" que se comparara con el valor esperado
            if((a.x[0] * w1 + a.x[1] * w2 + a.x[2] * w2 + a.x[3] * w2) + u > 0)//si la sumatoria de los pesos por las entradas
                                                    //"x" mas el valor del umbral es mayor a 0
            {
                y = 1;//y es igual a 1
            }
            else//en caso contrario
            {
                y = 0;//y es igual a 0
            }

            if (y != a.dx)//si y obtenida es diferente al valor esperado
            {
                //recalcular pesos y umbral
                w1 = w1 + (a.dx * a.x[0]);
                w2 = w2 + (a.dx * a.x[1]);
                w3 = w3 + (a.dx * a.x[2]);
                w4 = w4 + (a.dx * a.x[3]);
                u = u + a.dx;
                
                return b = 0;//regresar contador en 0
            }             
            else
                return b++;//regresar contador +1
        }
        public class Neurona//clase neurona posee n entradas x, y salida espera dx
        {
            public double[] x { get; set; }//crea vector de entradas x sin tamaño definido
            public double dx { get; set; }//dx es la salida esperda, o el valor de y esperado sea 1 o -1


            public Neurona(double[] x, double dx)
            {
                this.x = x;//este vector x es igual al vector x recibido (en teoria puede haceptar n entradas de x)

                this.dx = dx;//este vector dx es igual al dx recibido

            }
        }
    }
}
