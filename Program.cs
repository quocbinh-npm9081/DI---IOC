namespace DIIOC{
    interface Ivoid{
        public void SayHello();
    }
    class CVoidVN: Ivoid{
        public void SayHello(){
            Console.WriteLine("xin chao");
        }
    }
    class CVoidEN: Ivoid{
        public void SayHello(){
            Console.WriteLine("Hello");
        }
    }

    class CPeople{
        Ivoid voidHello;
        public CPeople(){

        }
        public  CPeople(Ivoid voidHello) => this.voidHello = voidHello;
        public void Hello(){
            voidHello.SayHello();
        }
    }

    class Program{
        static void Main(string[] args){
            CVoidEN voidEN = new CVoidEN();
            CVoidVN voidVN = new CVoidVN();
            CPeople nguoiVn = new CPeople(voidVN);
            CPeople nguoiMy = new CPeople(voidEN);
            nguoiVn.Hello();
        }
    }
}