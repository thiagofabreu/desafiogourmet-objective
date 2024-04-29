using DesafioGourmet_ConsoleApp.Models;
using System.ComponentModel;

namespace DesafioGourmet_ConsoleApp.Core
{
    public class FoodHandler
    {
        /// <summary>
        /// Esse método faz o gerenciamento das comidas, captura a comida que o usuário pensou e
        /// classifica ela na lista de comidas que for aprendendo.
        /// </summary>
        /// <param name="food">Objeto comida</param>
        /// <returns>retorna objeto aprendido</returns>
        public static Food FeedList(Food food)
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Qual é a comida que você pensou?");

            restartFood:
                var newFood = Console.ReadLine();

                if (string.IsNullOrEmpty(newFood))
                {
                    Console.WriteLine();
                    Console.WriteLine("Não captei sua mensagem. Digite qual é a comida que você pensou?");
                    goto restartFood;
                }

            restartClassification:
                Console.WriteLine($"{newFood} é _________________, mas {food.Name} não é.");

                var newClassification = Console.ReadLine();

                if (string.IsNullOrEmpty(newClassification))
                {
                    Console.WriteLine();
                    Console.WriteLine("Não entendi a classificação da comida que você pensou. Tente novamente, por favor.");
                    goto restartClassification;
                }

                var newFoodLearned = new Food(newFood, newClassification);

                return newFoodLearned;
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Reordena a lista de comidas mantendo as que foram inicializadas na primeira 
        /// e última posição
        /// </summary>
        /// <param name="list">List de comidas aprendidas</param>
        /// <returns>Lista de comidas reordenada</returns>
        public static List<Food> ReorderList(List<Food> list)
        {
            var listReordered = new List<Food>();

            var listInitializedValues = list.Where(p => p.InitialValues == true).OrderByDescending(p => p.Name).ToList();
            var listFeededList = list.Where(p => p.InitialValues == false).ToList();

            int contador = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                if (i == 0)
                {
                    listReordered.Add(listInitializedValues[0]);
                }

                if (i > 0 && i < list.Count() - 1)
                {
                    listReordered.Add(listFeededList[contador]);
                    contador++;
                }
                else if (i == list.Count() - 1)
                    listReordered.Add(listInitializedValues[1]);
            }

            return listReordered;
        }
    }
}
