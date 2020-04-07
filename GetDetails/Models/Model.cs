using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace GetDetails.Models
{
    public class CustomerVM
    {

        public string ID { get; set; }
        public string XMLSerialNo { get; set; }
        public string XMLPayorBankRoutNo { get; set; }
        public string XMLSAN { get; set; }
        public string XMLTransCode { get; set; }
        public string XMLAmount { get; set; }
        public string DbtAccNo { get; set; }
        public string ReturnCode { get; set; }
    }
}