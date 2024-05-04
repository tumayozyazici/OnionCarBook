using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Results.FooterAdressResults
{
    public class GetFooterAdressByIdQueryResult
    {
        public int FooterAdressID { get; set; }

        public string Description { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
