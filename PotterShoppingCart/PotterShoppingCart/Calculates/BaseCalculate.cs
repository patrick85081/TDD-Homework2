using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Calculates
{
    /// <summary>
    /// ��¦ ���˹��̼Ҧ� �򩳪��p��覡 (���t<see cref="DefaultCalculate"/>�\��)
    /// </summary>
    /// <seealso cref="PotterShoppingCart.Calculates.ICalculate" />
    public class BaseCalculate : ICalculate
    {
        private ICalculate _calculate = null;

        protected BaseCalculate()
        {
        }

        /// <summary>
        /// �N�h��<see cref="BaseCalculate"/>�զX�_��
        /// </summary>
        /// <param name="calculates">����p�⪫��</param>
        /// <returns>�զX�X�Ӫ�����p��</returns>
        public static BaseCalculate ComposeBaseCalculate(params BaseCalculate[] calculates)
        {
            if (calculates == null || calculates.Length == 0)
                return new BaseCalculate();

            BaseCalculate lastCalculate = null;

            using (var enumerator = calculates.Reverse().GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (lastCalculate != null)
                        current.SetCalculate(lastCalculate);
                    lastCalculate = current;
                }
            }

            return lastCalculate;
        }

        /// <summary>
        /// �[�J�p�⪫��
        /// </summary>
        /// <param name="calculate">The calculate.</param>
        public void SetCalculate(ICalculate calculate)
        {
            _calculate = calculate;
        }

        /// <summary>
        /// �p�ⲣ�~�`���B
        /// </summary>
        /// <param name="products">�ʶR���~�M��μƶq</param>
        /// <returns>
        /// �`���B
        /// </returns>
        /// <exception cref="System.ArgumentNullException">products</exception>
        public virtual double Calculate(IDictionary<Product, int> products)
        {
            if (products == null)
                throw new ArgumentNullException(
                    $"{nameof(products)} can`t be null.");

            return _calculate?.Calculate(products) ?? 
                products.Sum(p => p.Key.Price * p.Value);
        }
    }
}