using System;
using System.Collections.Generic;
namespace CriarUsarTipos
{
    public struct Nome{
        public String nome,sobrenome;

        public Nome(String p1, String p2){
            nome = p1;
            sobrenome = p2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //C# é uma linguagem fortemente tipada
            //toda a declaração de variavel deve ter um tipo definido
            int valor = 1;
            double valor2 = 2.2;
               
            //Quando não for definido o tipo deve-se usar a palavra chave var
            //dessa forma o compilador irá definir o valor da variavel
            var texto = "Hello world";
            Console.WriteLine(texto);

            //Pode-se gerar uma conversão sem perda de dados entre variaveis de tipos distintos
            valor2 = valor;
            Console.WriteLine(valor2);

            //Quando houver uma perda de dados deve-se gerar um cast via codigo fonte
            texto = "2.2";
            valor2 = Double.Parse(texto);
            Console.WriteLine(valor2);

            //Preenchendo um struct, struct e classes tem diferenças em tempo de compilação
            //Struct são tipos de valores  e por isso são lacrados e não podem ser herdados
            //Struct podem herdar somente de System.ValueType
            //Para o CLR os tipos de valores tem tratamento diferente a memoria
            //É alocada diretamente, não ha sobrecarga ou coleta de lixo
            Nome nome = new Nome("Demitrius", "Quadros");
            Console.WriteLine(nome.nome + " " + nome.sobrenome);
            
            
            int i = 123;
            //conversão boxing
            //converte em object e na memoria aloca o endereço de I
            object o = i;

            //conversão unboxing conver o valor dentro de o para um inteiro verdadeiro
            //extrai o valor real dentro de o e converte para inteiro
            int j  = (int) o;

            Console.WriteLine("Boxing conversion " + o);
            Console.WriteLine("Unboxing conversion " + j);

            //Tipos de referência, são instancias de classes interfaces ou delagados
            //tipo definido pelo usuário
            Tipos tipo = new Tipos();
            Console.WriteLine(tipo.Mensagem());
            
            //Todas as matrizes sao tipos de referencia de Systema.Array
            int[] nms = {1,2,3,4};
            foreach (var item in nms)
            {
                Console.WriteLine(item);
            }


            //Tipos de valores literais, voce pode inferir para o compilador qual é o 
            //tipo da informação acrescentando um literal ao final do número
            //Assim ele irá inferir o tipo conforme especificado
            var flt = 456.32F;
            Type tpo = flt.GetType();
            Console.WriteLine(tpo);
        
            //Tipos genéricos são tipos que podem ser declarados com um ou mais parametros de tipo
            //que servem como reservado para o tipo real. Exemplo uma lista tipada
            //Se o tipo for alterado na lista que ela foi fortemente ligada ira gerar
            //um erro de compilação
            List<string> stringList = new List<string>();
            stringList.Add("String example");

            //Tipos Implicitos - Recebe o seu tipo pelo compilador 
            var x = 123;
            Console.WriteLine(x.GetType());
            //Tipos anonimos, os mesmos retornados pelas estruturas do tipo linq, não precisam de definição
            //E só podem derivar de object, não podem ser passados por parametros a nao ser que o parametro
            //seja do tipo object.
            var anonimous = new { nome = "Demitrius", sobrenome = "Ruan Quadros"};
            Console.WriteLine(anonimous.nome + " " + anonimous.sobrenome);

            //Lista do tipo anonimo
            var anonlist =  new[] {new {fruta = "laranja", tamanho = "medio"}, new {fruta = "melancia", tamanho = "grande"}};

            foreach (var anon in anonlist)
            {
                Console.WriteLine("A fruta " + anon.fruta + " e " + anon.tamanho);
            }
        }

    }
}