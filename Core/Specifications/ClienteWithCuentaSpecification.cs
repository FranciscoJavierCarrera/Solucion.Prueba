using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ClienteWithCuentaSpecification :BaseSpecification<Cliente>
    {
        public ClienteWithCuentaSpecification(PageSpecificationParams pageParams) 
        {
            AddInclude(c => c.Cuentas);

            ApplyPaging(pageParams.PageSize*(pageParams.PageIngex-1), pageParams.PageSize);

            if (!string.IsNullOrEmpty(pageParams.Sort))
            {
                switch (pageParams.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "nombreDesc":
                        AddOrderDescendingBy(p => p.Nombre);
                        break;
                    case "apellidoPAsc":
                        AddOrderBy(p => p.ApellidoP);
                        break;
                    case "apellidoPDesc":
                        AddOrderDescendingBy(p => p.ApellidoP);
                        break;
                    case "identificacionAsc":
                        AddOrderBy(p => p.NumeroIdentificacion);
                        break;
                    case "identificacionDesc":
                        AddOrderDescendingBy(p => p.NumeroIdentificacion);
                        break;
                    default:
                        AddOrderBy(c => c.Id);
                        break;

                }
            }
        }
        public ClienteWithCuentaSpecification(int id ): base(x=> x.Id == id)
        {
            AddInclude(c => c.Cuentas);

        }
        

    }
}
