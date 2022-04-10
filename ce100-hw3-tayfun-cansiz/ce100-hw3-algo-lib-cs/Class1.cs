using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**********************************************************************************
***********************************************************************************
* @file ce100_hw3_algo_lib_cs *
* @author Tayfun CANSIZ *
* @date 9 April 2022 * 
*
* @brief <b> hw-3 Functions </b> *
*
* HW-3 Sample Lib Functions *
*
* @see http://bilgisayar.mmf.erdogan.edu.tr/en/
*
***********************************************************************************
***********************************************************************************/


namespace ce100_hw3_algo_lib_cs
{
    public class Class1
    {
        // Returns length of LCS for X[0..m-1], Y[0..n-1]
        public static string LongestCommonSubsquence(string R, string S, int a, int e)
        {
            int[,] L = new int[a + 1, e + 1];

            // Following steps build L[m+1][n+1] in
            // bottom up fashion. Note that L[i][j]
            // contains length of LCS of X[0..i-1]
            // and Y[0..j-1]
            for (int i = 0; i <= a; i++)
            {
                for (int j = 0; j <= e; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        L[i, j] = 0;
                    }
                    else if (R[i - 1] == S[j - 1])
                    {
                        L[i, j] = L[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                    }
                }
            }

            // Following code is used to print LCS
            int index = L[a, e];


            // Create a character array
            // to store the lcs string
            string lcs = string.Empty;



            // Start from the right-most-bottom-most corner
            // and one by one store characters in lcs[]
            int k = a, l = e;
            while (k > 0 && l > 0)
            {
                // If current character in X[] and Y
                // are same, then current character
                // is part of LCS
                if (R[k - 1] == S[l - 1])
                {
                    // Put current character in result
                    lcs = R[k - 1] + lcs;

                    // reduce values of i, j and index
                    k--;
                    l--;
                    index--;
                }

                // If not same, then find the larger of two and
                // go in the direction of larger value
                else if (L[k - 1, l] > L[k, l - 1])
                { k--; }
                else
                { l--; }
            }
            return lcs;
        }




        // Matrix Ai has dimension p[i - 1] x p[i]
        // for i = 1..n
        public static int MatrixChainOrder(int[] p, int i, int j)
        {

            if (i == j)
                return 0;

            int min = int.MaxValue;

            // place parenthesis at different places
            // between first and last matrix, recursively
            // calculate count of multiplications for each
            // parenthesis placement and return the
            // minimum count
            for (int k = i; k < j; k++)
            {
                int count = MatrixChainOrder(p, i, k)
                            + MatrixChainOrder(p, k + 1, j)
                            + p[i - 1] * p[k] * p[j];

                if (count < min)
                    min = count;
            }

            // Return minimum count
            return min;
        }
    }
}






      
    

