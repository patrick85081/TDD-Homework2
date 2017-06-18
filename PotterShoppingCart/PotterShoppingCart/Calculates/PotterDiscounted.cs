using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Calculates
{
    /// <summary>
    /// Potter�t�C�u�f
    /// </summary>
    /// <seealso cref="PotterShoppingCart.Calculates.BaseCalculate" />
    public class PotterDiscounted : BaseCalculate
    {
        /// <summary>
        /// �u�f�� �P�t�C���P�����ƶq
        /// </summary>
        private int _count;

        /// <summary>
        /// �u�f���馩
        /// </summary>
        private double _discounted;

        /// <summary>
        /// ���Q�i�S �馩�p��
        /// </summary>
        /// <param name="count">�u�f�� �P�t�C���P�����ƶq</param>
        /// <param name="discounted">�u�f���馩</param>
        public PotterDiscounted(int count, double discounted)
        {
            _count = count;
            _discounted = discounted;
        }

        /// <summary>
        /// �p���`���B
        /// </summary>
        /// <param name="products">�n�p�⪺�ӫ~</param>
        /// <returns></returns>
        public override double Calculate(IDictionary<Product, int> products)
        {
            if (products == null)
                throw new ArgumentNullException(
                    $"{nameof(products)} can`t be null.");

            // �L�o ���Q�i�S �t�C�ӫ~
            var potters = products.Where(p => p.Value > 0)
                .Where(p => p.Key.Series == "Harry Potter")
                .ToArray();

            var price = 0.0;
            IDictionary<Product, int> uncalculate = products;
            if (potters.Length >= _count)
            {
                // ���o�ŦX������y
                potters = potters.Take(_count)
                    .ToArray();

                // �ŦX���� �� �ռ�
                var groupNum = potters.Min(p => p.Value);

                // �ŦX���� �� �u�f��
                price = potters.Sum(p => p.Key.Price * groupNum)
                        * _discounted;

                // �Ѿl�|���p�⪺�ӫ~
                foreach (var potter in potters)
                {
                    if (products.ContainsKey(potter.Key))
                    {
                        products[potter.Key] -= groupNum;
                        if (products[potter.Key] <= 0)
                        {
                            products.Remove(potter.Key);
                        }
                    }
                }
            }

            // �^�ǮM�Φ��u�f������ �ѤU�٨S�Q�p�⪺�ӫ~ �M�ΤU�@�ӭp��覡
            return price + (uncalculate.Count > 0 ? base.Calculate(uncalculate) : 0);
        }
    }
}