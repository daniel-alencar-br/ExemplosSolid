using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosSolid
{

    // SOLID
    // S - Single Responsability (Responsabilidade Simples / Unica)
    //     Criar classes específicas para cada responsabilidade
    // 0 - Open / Closed (Aberto / Fechado)
    //     Aberta para extenção, mas fechada para alteração
    // L - Liskov Substitution (Substituição de Liskov)
    //     Os Filhos podem ser substituidos por referencias dos pais
    // I - Interface Segregation (Segregação de Interfaces)
    //     Interfaces Específicas ao invés de uma interface genérica
    // D - Dependency Inversion (Inversão de Dependecia)
    //     Depender de Abstrações e não de classes concretas

    public interface IMamiferos
    {
        void Mamar();
    }

    public interface ICarnivoro : IMamiferos
    {
        void ComerCarne();
    }

    public interface ICanideo : ICarnivoro
    {
        void Latem();
    }

    public class Cachorro : ICanideo
    {
        public void Mamar()
        {
            //
        }

        public void ComerCarne()
        {
            //
        }

        public void Latem()
        {
            //
        }
    }

    public class AlimentacaoZoologico
    {
        public void DarLeite(IMamiferos Bx)
        {
            Bx.Mamar();
        }

        public void DarCarne(ICarnivoro Bx)
        {
            Bx.ComerCarne();

            if (Bx is ICanideo)
                ((ICanideo)Bx).Latem();
        }

        public void DarCarne(ICanideo Bx)
        {
            Bx.Latem();
        }
    }


    public abstract class Poligono4Lados
    {
        public int Aresta1 { get; set; }
        public int Aresta2 { get; set; }
        public int Aresta3 { get; set; }
        public int Aresta4 { get; set; }
    }

    public class Quadrado : Poligono4Lados
    {
        //
    }

    public class CalculoArea
    {
        public int CalculoAreaPoligono4Lados(Poligono4Lados A)
        {
            return A.Aresta1 + A.Aresta2 + A.Aresta3 + A.Aresta4;
        }
    }

   
    public abstract class DebitoConta
    {
        public virtual void Debitar()
        { 
            // padrao...
        }
    }

    public sealed class DebitoContaCorrente : DebitoConta
    {
        public override void Debitar()
        {
            // A) Manter o Pai
            base.Debitar();
        }
    }

    public sealed class DebitoContaPoupanca : DebitoConta
    {
        public override void Debitar()
        {
            // B) Reescrever o metodo
            //
        }
    }

    public sealed class DebitoContaSalario: DebitoConta
    {
        public override void Debitar()
        {
            // C) Mantem o pai e incluir comportamento 

            base.Debitar();
            // + coisas
        }
    }

    // Interface
    // Interface -> Interface
    // Abstract Class -> Interface
    // Abstract Class -> Abstract Class
    // Concrete Class -> Interface
    // Concrete Class -> Abstract Class
    // Concrete Class -> Concrete Class

    // Sealed Concrete Class -> ....
    // The End (não dá mais)
    
    public interface IBanco
    {
        string Agencia { get; set; }
        string Conta { get; set; }
        void Conectar();
    }

    public interface IBancoPublico : IBanco
    {
        void AcessoGovBr();
    }

    public class Bradesco : IBanco
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }

        public Bradesco(string Age, string Con)
        {
            this.Agencia = Age;
            this.Conta = Con;
        }

        public void Conectar()
        {
            // 
        }
    }

    public class ModuloPagamentos
    {
        private IBanco BancoTemp;

        public ModuloPagamentos(IBanco Info)
        {
            BancoTemp = Info;
        }

        public void EnviarPix(string Chave, double valor)
        {
            BancoTemp.Conectar();

            Console.WriteLine("PIX Enviado do " + BancoTemp.ToString() +
                              " para " + Chave + " no valor de " +
                              valor.ToString());
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Bradesco Bc01 = new Bradesco("123", "4567");

            ModuloPagamentos Pag = new ModuloPagamentos(Bc01);
            Pag.EnviarPix("a@b.c", 100);

            //Console.ReadLine();

            Quadrado A = new Quadrado();
            A.Aresta1 = 10;
            A.Aresta2 = 10;
            A.Aresta3 = 10;
            A.Aresta4 = 10;

            CalculoArea Calc = new CalculoArea();

            Console.WriteLine(Calc.CalculoAreaPoligono4Lados(A).ToString());

            Console.ReadLine();

        }

    }
}