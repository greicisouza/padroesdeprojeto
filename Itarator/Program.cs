using System;
using System.Collections;
using System.Collections.Generic;

namespace Itarator
{
    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();
        // Retorna a chave do elemento atual
        public abstract int Key();
        // Retorna o elemento
        public abstract object Current();
        // Move para o próximo elemento
        public abstract bool MoveNext();
        // Retorna para o primeiro elemento
        public abstract void Reset();
    }

    abstract class Agregador : IEnumerable
    {
        // Retorna um iterator ou outro agregado para o objeto implementado
        public abstract IEnumerator GetEnumerator();
    }
    // Iteradores concretos implementam vários algoritmos de passagem. Essas classes
    // armazenam a posição transversal atual em todos os momentos.
    class OrdemAlfabetica : Iterator
    {
        private ColecaoPalavras _colecao;
        // Armazena a posição transversal atual. Um iterador pode ter muitos
        // outros campos para armazenar o estado de iteração, especialmente quando é
        // para trabalhar com um tipo específico de coleção.
        private int _posicao = -1;
        private bool _reverso = false;
        public OrdemAlfabetica(ColecaoPalavras colecao, bool reverse = false)
        {
            this._colecao = colecao;
            this._reverso = reverse;
            if (reverse)
            {
                this._posicao = colecao.getItems().Count;
            }
        }
        public override object Current()
        {
            return this._colecao.getItems()[_posicao];
        }
        public override int Key()
        {
            return this._posicao;
        }
        public override bool MoveNext()
        {
            int posicaoAtualizada = this._posicao + (this._reverso ? -1 : 1);
            if (posicaoAtualizada >= 0 && posicaoAtualizada < this._colecao.getItems().Count)
            {
                this._posicao = posicaoAtualizada;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._posicao = this._reverso ? this._colecao.getItems().Count - 1 : 0;
        }
    }

    // As coleções concretas fornecem um ou vários métodos para recuperar
    // instâncias de iterador, compatíveis com a classe de coleção.
    class ColecaoPalavras : Agregador
    {
        List<string> _colecao = new List<string>();
        bool _direcao = false;
        public void DirecaoReversa()
        {
            _direcao = !_direcao;
        }
        public List<string> getItems()
        {
            return _colecao;
        }
        public void AddItem(string item)
        {
            this._colecao.Add(item);
        }
        public override IEnumerator GetEnumerator()
        {
            return new OrdemAlfabetica(this, _direcao);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var colecao = new ColecaoPalavras();
            colecao.AddItem("Primeiro");
            colecao.AddItem("Segundo");
            colecao.AddItem("Terceiro");
            Console.WriteLine("Posição Normal:");
            foreach (var elemento in colecao)
            {
                Console.WriteLine(elemento);
            }
            Console.WriteLine("\nReverso:");
            colecao.DirecaoReversa();
            foreach (var elemento in colecao)
            {
                Console.WriteLine(elemento);
            }
        }
    }
}