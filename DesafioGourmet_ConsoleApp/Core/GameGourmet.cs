using DesafioGourmet_ConsoleApp.Dialogs;
using DesafioGourmet_ConsoleApp.Models;
using System.Data;

namespace DesafioGourmet_ConsoleApp.Core
{
    public static class GameGourmet
    {
        #region Attributes

        private static List<Food> _foods = new List<Food>();
        private static string _messageToStartThinking = "Pense em uma comida que você goste...";
        private static int _secondsToWait = 3;
        #endregion

        #region Public Methods

        /// <summary>
        /// Fluxo de START do Desafio
        /// </summary>
        public static void Start()
        {
            Console.WriteLine(_messageToStartThinking);

            Wait(_secondsToWait);

            Initializer.Fill(_foods);

            ScrollListOfFoods();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Método responsável por percorrer a lista de comidas que o app 
        /// tem e tentar descobrir.
        /// Caso não descubra, faz a pergunta do que é e guarda o que aprendeu.
        /// Depois, reinicia a advinhação.
        /// </summary>
        private static void ScrollListOfFoods()
        {

        restart:
            bool positiveAnswer = false;
            bool learnedNewFood = false;
            int totalFoods = 0;

            foreach (var food in _foods)
            {
                totalFoods++;

                var responseClassification = TryDiscover(food, true);

                if (responseClassification)
                {
                    var responseFoodName = TryDiscover(food, false);

                    if (responseFoodName)
                        Dialog.DiscoveredTheFood();
                    else
                    {
                        var foodListFiltered = _foods.Where(p => 
                                    p.Classification.ToLower() == food.Classification.ToLower()
                                    && p.Name != food.Name);

                        bool foundTheFood = false;

                        if (foodListFiltered.Any())
                        {
                            //Percorre a lista de comidas com a mesma classificação
                            foreach (var foodFiltered in foodListFiltered)
                            {
                                if (TryDiscover(foodFiltered, false))
                                {
                                    Dialog.DiscoveredTheFood();
                                    foundTheFood = true;
                                }
                            }
                        }

                        if (!foodListFiltered.Any() || !foundTheFood)
                        {
                            _foods.Add(FoodHandler.FeedList(food));
                            _foods = FoodHandler.ReorderList(_foods);
                            
                            learnedNewFood = true;

                            break;
                        }
                    }
                }
                else
                {
                    if (totalFoods == _foods.Count())
                    {
                        if (!positiveAnswer)
                        {
                            _foods.Add(FoodHandler.FeedList(food));
                            _foods = FoodHandler.ReorderList(_foods);
                            
                            learnedNewFood = true;

                            break;
                        }
                    }
                }
            }

            if (learnedNewFood)
            {
                Console.Clear();
                Console.WriteLine(_messageToStartThinking);

                Wait(_secondsToWait);

                goto restart;
            }
        }

        /// <summary>
        /// Método que tenta descobrir a comida e captura a resposta do usuário.
        /// Pode tentar pelo nome da comida ou pela classificação.
        /// </summary>
        /// <param name="food">Objeto Comida</param>
        /// <param name="askClassification">Se deve usar a Classificação na pergunta</param>
        /// <returns>Boolean</returns>
        private static bool TryDiscover(Food food, bool askClassification)
        {
            bool? response;

        restart:
            if (!askClassification)
            {
                response = Dialog.AskToUser($"A comida que você pensou é {food.Name} ?");
            }
            else
            {
                response = Dialog.AskToUser($"A comida que você pensou é {food.Classification} ?");
            }

            if (response == null)
                goto restart;
            else
                return response.Value;
        }

        /// <summary>
        /// Método que faz a espera na tela, para não ficar
        /// mensagem uma na sequência de outra
        /// </summary>
        /// <param name="seconds">Segundos para esperar</param>
        private static void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        #endregion


    }
}
