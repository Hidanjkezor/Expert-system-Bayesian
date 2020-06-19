using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayesian_network_ES
{
    public class Node
    {
        public string NameFact { get; set; }

        public int ID { get; }

        public List<double> Probabilities { get => _probabilities; }

        private List<double> _probabilities;

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
            _probabilities = new List<double>(countProb);

            for (int i = 0; i < countProb; i++)
            {
                _probabilities.Add(-1);
            }
        }

        /// <summary>
        /// Set value of currect probability
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetProbability(int index, double value)
        {
            if (index < _probabilities.Count && value > 0 && value <= 1)
            {
                _probabilities[index] = value;
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
            foreach (var prob in _probabilities)
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
            if (index <= _probabilities.Count)
            {
                return conditionalProb(binCode);
            }
            else
            {
                //Исключение
                return null;
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
            int countParents = (int)Math.Log(_probabilities.Count, 2);
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
