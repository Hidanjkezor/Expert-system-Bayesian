using System;
using System.Collections.Generic;
using System.Linq;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Class nodes in Bayesian network
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Name of node
        /// </summary>
        public string NameFact { get; set; }

        /// <summary>
        /// ID of node
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// List probabilities in Bayesian network
        /// </summary>
        public List<double> Probabilities { get; private set; }

        /// <summary>
        /// Create node of Bayesian network
        /// </summary>
        /// <param name="NameFact"></param>
        /// <param name="ID"></param>
        public Node(string NameFact, int ID) 
        {
            this.NameFact = NameFact;
            this.ID = ID;
        }

        /// <summary>
        /// Initialize list probabilities with default values
        /// </summary>
        /// <param name="countParents"></param>
        public void InitProbabilities(int countParents)
        {
            int countProb = (int)Math.Pow(2, countParents);
            Probabilities = new List<double>(countProb);

            for (int i = 0; i < countProb; i++)
            {
                Probabilities.Add(-1);
            }
        }

        /// <summary>
        /// Set value of currect probability
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetProbability(int index, double value)
        {
            if (index < Probabilities.Count && value > 0 && value <= 1)
            {
                Probabilities[index] = value;
            }
            else
            {
                throw new Exception("Значение вероятности должно быть" +
                    " меньше 1 и больше 0");
            }
        }

        /// <summary>
        /// Set probabilities by enter values
        /// </summary>
        /// <param name="values"></param>
        public void SetProbability(List<double> values)
        {
            int countValues = values.Count;
            for (int i = 0; i < countValues; i++)
            {
                SetProbability(i, values[i]);
            }
        }

        /// <summary>
        /// Is every probability entered
        /// </summary>
        /// <returns></returns>
        public bool CheckProbabilities()
        {
            foreach (var prob in Probabilities)
            {
                if (prob == -1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Return string with logic formula
        /// </summary>
        /// <param name="index">Int with binary code</param>
        /// <returns></returns>
        public string conditionalProb(int index)
        {
            string binCode = Convert.ToString(index, 2);
            if (index <= Probabilities.Count)
            {
                return conditionalProb(binCode);
            }
            else
            {
                throw new Exception("Индекс вышел за пределы массива");
            }
            
        }

        /// <summary>
        /// Return string with logic formula
        /// </summary>
        /// <param name="binCode">String with binary code</param>
        /// <returns></returns>
        public string conditionalProb(string binCode)
        {
            string res = "";
            int countBinCode = binCode.Length;
            int countParents = (int)Math.Log(Probabilities.Count, 2);
            char logicChar = (char)('a' + countParents - 1);

            for (int index = countBinCode - 1; index >= 0; index--)
            {
                res += logicChar--;
                if (binCode[index] == '1')
                {
                    res += '~';
                }
            }

            while (logicChar >= 'a')
            {
                res += logicChar--;
            }

            return new string(res.Reverse().ToArray());
        }
    }
}