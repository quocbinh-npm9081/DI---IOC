﻿namespace DIIOC{
    class ClassC {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB {
        // Phụ thuộc của ClassB là ClassC
        ClassC c_dependency;

        public ClassB(ClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA {
        // Phụ thuộc của ClassA là ClassB
        ClassB b_dependency;

        public ClassA(ClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    class Program{
        static void Main(string[] args){
            ClassC classc = new ClassC();
            ClassB classb = new ClassB(classc);
            ClassA classa = new ClassA(classb);
            classa.ActionA();
        }
    }
}