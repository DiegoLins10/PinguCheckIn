using PinguCheckIn.Data;
using System;
using System.Linq;
using System.Globalization;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace PinguCheckIn.Negocio
{
    public abstract class NegocioBase
    {
        public PinguCheckInContext Contexto { get; set; }

        public NegocioBase()
        {
            this.Contexto = new Contexto();
        }
    }

    public abstract class NegocioBase<TEntidade> : NegocioBase where TEntidade : class, new()
    {
        public virtual IEnumerable<TEntidade> Enumerar()
        {
            return this.Contexto.Set<TEntidade>();
        }

        public virtual IEnumerable<TEntidade> Enumerar(Expression<Func<TEntidade, bool>> filtro)
        {
            return this.Contexto.Set<TEntidade>().Where(filtro);
        }

        public virtual TEntidade Obter(int id)
        {
            return this.Contexto.Find<TEntidade>(id);
        }

        public virtual TEntidade Obter(Expression<Func<TEntidade, bool>> filtro)
        {
            return this.Contexto.Set<TEntidade>().FirstOrDefault(filtro);
        }
    }
}
