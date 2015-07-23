using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;
namespace s100_ventacalzado
{
    class MyData
    {
        public static People mypeople_a;
    }

    public class myObject
    {
        //Private members for all the below described properties
        //Public Properties  
        public String id_a;
        public String descripcion_a;

        //Methods
        //Constructor
        public myObject(String id_p, String descripcion_p)
        {
            id_a = id_p;
            descripcion_a = descripcion_p;

        }
    }

    public class myObjectList : List<myObject>
    { }  

}
