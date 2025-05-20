namespace Amaury5TTIProjetPuissance4
{
    internal class Program
    {

class Puissance4
    {
        static void Main()
        {
                mesOutils fonctionP4 = new mesOutils();

                fonctionP4.InitialiserGrille();

            char joueurActuel = 'J'; // J = jaune, R = rouge

            while (true)
            {
                fonctionP4.AfficherGrille();
                Console.WriteLine($"Au tour du joueur {(joueurActuel == 'J' ? "Jaune (J)" : "Rouge (R)")}");

                int colonne = -1;
                bool entreeValide = false;

                while (!entreeValide)
                {
                    Console.Write("Choisissez une colonne (1 à 7) : ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out colonne) && colonne >= 1 && colonne <= 7)
                    {
                        if (fonctionP4.JouerCoup(colonne - 1, joueurActuel))
                        {
                            entreeValide = true;
                        }
                        else
                        {
                            Console.WriteLine(" Cette colonne est pleine. Choisissez-en une autre.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Entrée invalide. Veuillez entrer un **nombre** entre 1 et 7.");
                    }
                }

                if (fonctionP4.VerifierVictoire(joueurActuel))
                {
                    fonctionP4.AfficherGrille();
                    Console.WriteLine($" Le joueur {(joueurActuel == 'J' ? "Jaune (J)" : "Rouge (R)")} a gagné félicitation !");
                    break;
                }

                if (fonctionP4.GrillePleine())
                {
                    fonctionP4.AfficherGrille();
                    Console.WriteLine("Match nul !");
                    break;
                }

                joueurActuel = joueurActuel == 'J' ? 'R' : 'J';
            }
        }

       
    }
}
}

