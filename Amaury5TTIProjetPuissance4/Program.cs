namespace Amaury5TTIProjetPuissance4
{
    internal class Program
    {

class Puissance4
    {
        const int lignes = 6;
        const int colonnes = 7;
        static char[,] grille = new char[lignes, colonnes];

        static void Main()
        {
            InitialiserGrille();
            char joueurActuel = 'J'; // J = jaune, R = rouge

            while (true)
            {
                AfficherGrille();
                Console.WriteLine($"Au tour du joueur {(joueurActuel == 'J' ? "Jaune (J)" : "Rouge (R)")}");

                int colonne = -1;
                bool entreeValide = false;

                while (!entreeValide)
                {
                    Console.Write("Choisissez une colonne (1 à 7) : ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out colonne) && colonne >= 1 && colonne <= 7)
                    {
                        if (JouerCoup(colonne - 1, joueurActuel))
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

                if (VerifierVictoire(joueurActuel))
                {
                    AfficherGrille();
                    Console.WriteLine($" Le joueur {(joueurActuel == 'J' ? "Jaune (J)" : "Rouge (R)")} a gagné !");
                    break;
                }

                if (GrillePleine())
                {
                    AfficherGrille();
                    Console.WriteLine("Match nul !");
                    break;
                }

                joueurActuel = joueurActuel == 'J' ? 'R' : 'J';
            }
        }

        static void InitialiserGrille()
        {
            for (int i = 0; i < lignes; i++)
                for (int j = 0; j < colonnes; j++)
                    grille[i, j] = '.';
        }

        static void AfficherGrille()
        {
            Console.Clear();
            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    if (grille[i, j] == 'J')
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else if (grille[i, j] == 'R')
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ResetColor();

                    Console.Write(grille[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("1 2 3 4 5 6 7");
        }

        static bool JouerCoup(int colonne, char pion)
        {
            for (int i = lignes - 1; i >= 0; i--)
            {
                if (grille[i, colonne] == '.')
                {
                    grille[i, colonne] = pion;
                    return true;
                }
            }
            return false;
        }

        static bool VerifierVictoire(char pion)
        {
            // Horizontal
            for (int i = 0; i < lignes; i++)
                for (int j = 0; j < colonnes - 3; j++)
                    if (grille[i, j] == pion && grille[i, j + 1] == pion && grille[i, j + 2] == pion && grille[i, j + 3] == pion)
                        return true;

            // Vertical
            for (int j = 0; j < colonnes; j++)
                for (int i = 0; i < lignes - 3; i++)
                    if (grille[i, j] == pion && grille[i + 1, j] == pion && grille[i + 2, j] == pion && grille[i + 3, j] == pion)
                        return true;

            // Diagonale (bas-gauche vers haut-droit)
            for (int i = 3; i < lignes; i++)
                for (int j = 0; j < colonnes - 3; j++)
                    if (grille[i, j] == pion && grille[i - 1, j + 1] == pion && grille[i - 2, j + 2] == pion && grille[i - 3, j + 3] == pion)
                        return true;

            // Diagonale (haut-gauche vers bas-droit)
            for (int i = 0; i < lignes - 3; i++)
                for (int j = 0; j < colonnes - 3; j++)
                    if (grille[i, j] == pion && grille[i + 1, j + 1] == pion && grille[i + 2, j + 2] == pion && grille[i + 3, j + 3] == pion)
                        return true;

            return false;
        }

        static bool GrillePleine()
        {
            for (int j = 0; j < colonnes; j++)
                if (grille[0, j] == '.')
                    return false;
            return true;
        }
    }
}
}
