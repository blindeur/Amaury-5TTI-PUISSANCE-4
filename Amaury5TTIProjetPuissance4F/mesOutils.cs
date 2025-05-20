using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaury5TTIProjetPuissance4
{
    internal class mesOutils
    {
        public const int lignes = 6;
       public const int colonnes = 7;
        public static char[,] grille = new char[lignes, colonnes];

        public void InitialiserGrille()
        {
            for (int i = 0; i < lignes; i++)
                for (int j = 0; j < colonnes; j++)
                    grille[i, j] =  '.';
        }

        public void AfficherGrille()
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

        public bool JouerCoup(int colonne, char pion)
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

        public bool VerifierVictoire(char pion)
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

        public bool GrillePleine()
        {
            for (int j = 0; j < colonnes; j++)
                if (grille[0, j] == '.')
                    return false;
            return true;
        }
    }
}
