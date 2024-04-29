namespace DesafioGourmet_ConsoleApp.Dialogs
{
    /// <summary>
    /// Classe que representa todas as mensagens de diálogo 
    /// que serão apresentadas para o usuário
    /// </summary>
    public static class Dialog
    {
        #region Attributes

        private static char _keyYes = 'S';
        private static char _keyNo = 'M';

        #endregion

        #region Static Methods

        /// <summary>
        /// Mostra mensagem que descobriu a comida
        /// </summary>
        public static void DiscoveredTheFood()
        {
            Console.Clear();

            Console.WriteLine("Eu ganhei, descobri sua comida!");
            Console.WriteLine();
            Console.WriteLine("Pressione uma tecla para começarmos novamente");

            Console.ReadLine();
        }

        /// <summary>
        /// Faz uma pergunta e espera a resposta do usuário
        /// </summary>
        /// <param name="question">Pergunta para ser respondida</param>
        /// <returns>Boolean (baseado na resposta S ou N)</returns>
        public static bool? AskToUser(string question)
        {
            Console.WriteLine();
            Console.WriteLine(string.Concat(question, " (S/N)"));

            var keyPressed = Console.ReadKey(true);
            Console.WriteLine(keyPressed.KeyChar);

            if (!new char[] { 'S', 'N' }.Contains(keyPressed.KeyChar))
            {
                Console.WriteLine();
                Console.WriteLine("Tecla inválida. Você deve teclar S para SIM ou N para não.");

                return null;
            }
            else
                return char.ToUpper(keyPressed.KeyChar) == 'S';
        }

        #endregion

    }
}
