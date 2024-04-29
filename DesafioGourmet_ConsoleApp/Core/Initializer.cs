using DesafioGourmet_ConsoleApp.Models;

namespace DesafioGourmet_ConsoleApp.Core
{
    public static class Initializer
    {
        /// <summary>
        /// Inicializa a lista básica de valores iniciais
        /// </summary>
        /// <param name="foodList"></param>
        public static void Fill(List<Food> foodList)
        {
            if (foodList.Any(p => p.InitialValues))
                return;

            foodList.AddRange(new List<Food>{
                new Food("Bolo de Chocolate", "Bolo", true),
                new Food("Lasanha", "Massa", true)
            });
        }
    }
}
