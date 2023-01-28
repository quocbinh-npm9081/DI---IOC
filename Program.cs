using Microsoft.Extensions.DependencyInjection;
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
        public CPeople(Ivoid voidHello) => this.voidHello = voidHello;
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
           //nguoiVn.Hello();

            //su dung Framework Dependency injection
            //DI container : ServiceCollection
            // - Dang ky cac dich vu( lop)
            // - ServiceProvider -> Get Service |
            
            //STEP 1: dang ky dich vu
            var services = new ServiceCollection();

        

            //kiểu service Singleton (tồn tại duy nhất xuốt vòng đời của nó) tắt chương trình chạy lại thì nó  ko phải tạo lại
            //services.AddSingleton<Ivoid, CVoidVN>();

            //kiểu Transient Một phiên bản của dịch vụ được tạo mỗi khi được yêu cầu kết thúc nó sẽ tạo mới
            //services.AddTransient<Ivoid, CVoidEN>();

            //Kiểu scoped , dịch vụ chỉ dc tạo và sử dụng được trong phạm vi nhất định
           //services.AddScoped<Ivoid, CVoidEN>();

            //SETP 2: tao provider
            // var provider = services.BuildServiceProvider();
            // for (int i = 0; i < 5; i++){
            //     Ivoid c = provider.GetService<Ivoid>();
            //     Console.WriteLine(c.GetHashCode());
            // }

            //Tạo 1 scrop mới
            //  Console.WriteLine("++++ scrop service moi +++++");

            // using (var scoped = provider.CreateScope()){
            //     var provider1 = scoped.ServiceProvider;
            //     for (int i = 0; i < 5; i++){
            //         Ivoid c = provider1.GetService<Ivoid>();
            //         Console.WriteLine(c.GetHashCode());
            //     }
            // }

            services.AddSingleton<Ivoid,CVoidVN>();
            services.AddSingleton<Ivoid,CVoidEN>();
            services.AddSingleton<CPeople,CPeople>();
            var provider = services.BuildServiceProvider();
            CPeople peopleEN = provider.GetService<CPeople>();

            peopleEN.Hello();





        }
    }
}