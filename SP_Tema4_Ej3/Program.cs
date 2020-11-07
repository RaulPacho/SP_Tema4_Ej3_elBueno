using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SP_Tema4_Ej3
{
    class Program
    {
        static readonly private object l = new object();
        public static int var = 0;
        public static bool ended = false;
        static void Main(string[] args)
        {
            
            Thread thAdd = new Thread(() =>
            {
                
                while (var < 1000 && !ended)
                {

                    lock (l)
                    {
                        if (!ended)
                        {
                            var++;
                            Console.WriteLine(var + " -> thread Add");
                            if (var >= 1000) ended = true;
                        }
                    }
                    
                }
            });

            Thread thSus = new Thread(() =>
            {

                while (var > -1000 && !ended)
                {
                    if (ended) { break; }
                    lock (l)
                        {
                        if (!ended)
                        {
                            var--;
                            Console.WriteLine(var + " -> thread Sus");
                            if (var <= -1000) ended = true;
                        }
                    }

                    
                }

               


            });

            thAdd.Start();
            thSus.Start();

           
            Console.ReadLine();
        }

        /*  public static void Sustract()
          {

              while (var > -1000)
              {
                  if (!acabo)
                  {

                          var--;
                          Console.WriteLine(var + " -> thRes");

                  }
                  else
                  {
                      break;
                  }
              }

              acabo = true;


          }

          public static void Increment()
          {

              while (var < 1000)
              {
                  if (!acabo)
                  {
                          var++;
                          Console.WriteLine(var + " -> thSum");
                  }
                  else
                  {
                      break;
                  }
              }
              acabo = true;
              }
          }*/
    }
    
}
