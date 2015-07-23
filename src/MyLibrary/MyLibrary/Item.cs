using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class Item
    {
        public String Index;
        public String Descripcion;


        public Item(String Index_p, String Descripcion_p)
        {
            Index = Index_p;
            Descripcion = Descripcion_p;
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public String Value()
        {
            return Index;
        }

    }

}
