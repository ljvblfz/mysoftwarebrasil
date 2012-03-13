//
//  Copyright (c) 2009, WebAula S/A 
//  All rights reserved.
//
//  Authors: 
//               
//           * Ivan Paulovich (ivan@100loop.com)
//           Blog: http://www.100loop.com/          
//           Messenger: ivanpaulovich@hotmail.com 
//

using System;

namespace PontoEncontro.Infrastructure.MVC.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToLMSText(this DateTime date)
        {
            
            var diffTotalHours = DateTime.Now.Subtract(date).TotalHours;

            if (diffTotalHours < 48)
            {

                if (diffTotalHours < 24)
                {
                    if (diffTotalHours < 1)
                    {

                        if (DateTime.Now.Subtract(date).Minutes < 2)
                        {
                            return "agora";
                        }
                        else
                        {
                            return "há " + DateTime.Now.Subtract(date).Minutes + " minutos";
                        }

                    }
                    else
                    {
                        return "há " + DateTime.Now.Subtract(date).Hours + " horas";
                    }
                }
                else
                {
                    return "- ontem às " + date.ToShortTimeString();
                }

            }
            else
            {
                return "- " + date.ToLongDateString() + " às " + date.ToShortTimeString();
            }

        }
    }
}