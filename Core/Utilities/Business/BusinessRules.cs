using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//parametre olarak gönderilen
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)//durumu başarısız olanları
                {
                    return logic; //döndür
                }
            }

            return null;
        }
    }
}
