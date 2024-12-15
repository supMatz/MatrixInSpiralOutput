using System;

namespace Output_Spirale_Matrix_Cerioni
{
    class Program
    {
        private static void Main(string[] args)
        {
            int righe_matrix = 0;
            int colonne_matrix = 0;
            int[,] matrix = new int[0,0];

            //inserisci le dimensioni della matrice
            inserisci_righe_colonne_matrix(ref matrix, ref righe_matrix, ref colonne_matrix);

            matrix = new int[righe_matrix, colonne_matrix]; //dimensione dinamica

            //popola la matrice con numeri interi (usando un contatore)
            popola_matrix_interi(ref matrix, ref righe_matrix, ref colonne_matrix);

            //visualizza la matrice in modo a spirale
            Console.WriteLine("Matrice a spirale : ");

            display_matrix_spirale(matrix, 0, righe_matrix, 0, colonne_matrix);

            Console.ReadLine();
        }

        private static void popola_matrix_interi(ref int[,] matrix, ref int r, ref int c)
        {
            if (r > 0 && c > 0)
            {
                int numero_cella = 0;

                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        matrix[i, j] = ++numero_cella;
                    }
                }

                Console.WriteLine("Matrice popolata con successo!");
            }
            else
            {
                Console.WriteLine("Inserire un numero di righe e uno di colonne (maggiore di 1)");
            }
        }

        private static void display_matrix_spirale(int[,] matrix, int num_riga_inizio, int r, int num_colonna_inizio, int c)
        {
            //controllo per evitare cicli infiniti di ricorsione
            if (num_riga_inizio >= r || num_colonna_inizio >= c) return;

            //stampa la riga superiore
            for (int i = num_colonna_inizio; i < c; i++)
                Console.Write(matrix[num_riga_inizio, i].ToString() + " ");
            num_riga_inizio++;

            //stampa la colonna destra
            for (int i = num_riga_inizio; i < r; i++)
                Console.Write(matrix[i, c--].ToString() + " ");
            c--;

            //stampa la riga inferiore (se esiste)
            if (num_riga_inizio < r)
            {
                for (int i = c--; i >= num_colonna_inizio; i--)
                    Console.Write(matrix[r--, i].ToString() + " ");
                r--;
            }

            //stampa la colonna sinistra (se esiste)
            if (num_colonna_inizio < c)
            {
                for (int i = r - 1; i >= num_riga_inizio; i--)
                    Console.Write(matrix[i, num_colonna_inizio].ToString() + " ");
                num_colonna_inizio++;
            }

            //ricorsione
            display_matrix_spirale(matrix, num_riga_inizio, r, num_colonna_inizio, c);
            Console.WriteLine("");
        }

        private static void inserisci_righe_colonne_matrix(ref int[,] matrix, ref int righe_matrix, ref int colonne_matrix)
        {
            // Inserimento righe
            Console.Write("Inserisci il numero (int) di righe della matrice : ");
            righe_matrix = Convert.ToInt16(Console.ReadLine());

            // Inserimento colonne
            Console.Write("Inserisci il numero (int) di colonne della matrice : ");
            colonne_matrix = Convert.ToInt16(Console.ReadLine());

            Console.Clear(); // Pulizia dopo le assegnazioni
        }
    }
}
