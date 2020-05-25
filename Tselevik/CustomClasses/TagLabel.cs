using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tselevik { 
    public class TagLabel : Label
    {
        public static readonly BindableProperty TagProperty =
            BindableProperty.Create("Tag", // название обычного свойства
                typeof(string), // возвращаемый тип 
                typeof(TagLabel), // тип,  котором объявляется свойство
                "0"// значение по умолчанию
            );

        public string Tag
        {
            set
            {
                SetValue(TagProperty, value);
            }
            get
            {
                return (string)GetValue(TagProperty);
            }
        }
    }
}