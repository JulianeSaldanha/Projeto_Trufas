using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Domain;

namespace Trufaria.Test
{
    public class ObjectMother
    {
        public static Trufa GetTrufa()
        {
            Trufa trufa = new Trufa();
            trufa.DataFabricacao = new DateTime(2015, 06, 15, 0, 0, 0);
            trufa.DataValidade = new DateTime(2015, 06, 25, 0, 0, 0);
            trufa.Quantidade = 5;
            trufa.Tamanho = "Grande";
            trufa.Valor = 3.00;
            trufa.Sabores = new List<Sabor>()
            {
                new Sabor()
                {
                    NameSabor = "Brigadeiro"
                }
            };

            return trufa; 
        }

        public static Sabor GetSabor()
        {
            Sabor sabor = new Sabor();
            sabor.NameSabor = "Brigadeiro";

            return sabor;
        } 

        public static List<Sabor> GetSabores()
        {
            List<Sabor> sabores = new List<Sabor>();

            Trufa trufa = new Trufa();
            trufa.DataFabricacao = new DateTime(2015, 04, 01, 0, 0, 0);
            trufa.DataValidade = new DateTime(2015, 04, 11, 0, 0, 0);
            trufa.Quantidade = 5;
            trufa.Tamanho = "Grande";
            trufa.Valor = 3.00;

            Sabor sabor = new Sabor();
            sabor.NameSabor = "Brigadeiro de Chocolate";
            //sabor.TrufaId = 1;

            Sabor sabor2 = new Sabor();
            sabor2.NameSabor = "Brigadeiro de Morango";
           // sabor2.TrufaId = 2;

            Sabor sabor3 = new Sabor();
            sabor3.NameSabor = "Beijinho";
           // sabor3.TrufaId = 3;
            
            Sabor sabor4 = new Sabor();
            sabor4.NameSabor = "Creme de coco com abacaxi";
            //sabor4.TrufaId = 4;

            Sabor sabor5 = new Sabor();
            sabor5.NameSabor = "Maracuja";
            //sabor5.TrufaId = 5;
            
            Sabor sabor6 = new Sabor();
            sabor6.NameSabor = "Morango com leite condensado";
            //sabor6.TrufaId = 6;

            sabores.Add(sabor);
            sabores.Add(sabor2);
            sabores.Add(sabor3);
            sabores.Add(sabor4);
            sabores.Add(sabor5);
            sabores.Add(sabor6);


            return sabores;
        }

    }
}
    
